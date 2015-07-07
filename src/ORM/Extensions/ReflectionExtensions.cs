using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace sORM.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            return type.FindInterfaces(FilterByName, interfaceType).Length > 0;
        }
        private static bool FilterByName(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }

        public static Delegate CreateDelegate(this MethodInfo method, params Type[] parameters)
        {
            if (method == null) throw new ArgumentNullException("method");
            if (parameters == null) throw new ArgumentNullException("parameters");

            var types = (from parameter in method.GetParameters()
                         select parameter.ParameterType).ToArray();

            if (parameters.Length != types.Length) throw new Exception("Method parameters count is not equals to parameters count.");

            var dynamicMethod = new DynamicMethod(string.Empty, method.ReturnType, new[] { typeof(object) }.Concat(parameters).ToArray(), true);
            var generator = dynamicMethod.GetILGenerator();

            if (!method.IsStatic)
            {
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(method.DeclaringType.IsClass ? OpCodes.Castclass : OpCodes.Unbox, method.DeclaringType);
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                generator.Emit(OpCodes.Ldarg, i + 1);
                if (parameters[i] != types[i])
                {
                    if (!types[i].IsSubclassOf(parameters[i]) && !types[i].HasInterface(parameters[i])) throw new Exception(string.Format("Cannot cast from {0} to {1}.", types[i].Name, parameters[i].Name));

                    generator.Emit(types[i].IsClass ? OpCodes.Castclass : OpCodes.Unbox, types[i]);
                }
            }

            generator.Emit(OpCodes.Call, method);
            generator.Emit(OpCodes.Ret);

            if (method.ReturnType == typeof(void))
            {
                return dynamicMethod.CreateDelegate(Expression.GetActionType(new[] { typeof(object) }.Concat(parameters).ToArray<Type>()));
            }
            else
            {
                return dynamicMethod.CreateDelegate(Expression.GetFuncType(new[] { typeof(object) }.Concat(parameters).Concat(new[] { method.ReturnType }).ToArray<Type>()));
            }
        }
    }
}
