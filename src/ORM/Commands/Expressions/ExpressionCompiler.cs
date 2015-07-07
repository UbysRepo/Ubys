using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using sORM.Extensions;
using System.Text;
using sORM.Schema.Interfaces;

namespace sORM.Commands.Expressions
{
    public class ExpressionCompiler
    {
        // FIELDS
        private static readonly Dictionary<ExpressionType, string> _expressionsType = new Dictionary<ExpressionType, string>
        {
            { ExpressionType.AndAlso, "AND" },
            { ExpressionType.OrElse, "OR" },
            { ExpressionType.Equal, "=" },
            { ExpressionType.NotEqual, "<>" },
            { ExpressionType.GreaterThan, ">" },
            { ExpressionType.GreaterThanOrEqual, ">=" },
            { ExpressionType.LessThan, "<" },
            { ExpressionType.LessThanOrEqual, "<=" }
        };

        private static ExpressionCompiler _instance;

        private readonly Dictionary<Type, Func<object, Database, Expression, ICommand, string>> m_methods;

        // PROPERTIES

        // CONSTRUCTORS
        private ExpressionCompiler()
        {
            this.m_methods = new Dictionary<Type, Func<object, Database, Expression, ICommand, string>>();

            this.Initialize();
        }

        // METHODS
        private void Initialize()
        {
            var methods = (from method in typeof(ExpressionCompiler).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                           where method.ReturnType == typeof(string)
                           where method.Name == "GenerateExpression"
                           select method)
                          .ToArray();

            for (int i = 0; i < methods.Length; i++)
            {
                var method = methods[i];
                var parameters = method.GetParameters();

                if (parameters.Length == 3)
                {
                    if (parameters[0].ParameterType == typeof(Database))
                    {
                        var parameter = parameters[1];

                        if (parameter.ParameterType.IsSubclassOf(typeof(Expression)) && !this.m_methods.ContainsKey(parameter.ParameterType))
                        {
                            this.m_methods.Add(parameter.ParameterType, 
                                (Func<object, Database, Expression, ICommand, string>)method.CreateDelegate(new[] { typeof(Database), typeof(Expression), typeof(ICommand) }));
                        }
                    }
                }
            }
        }

        public string ReturnExpression(Database database, Expression expression, ICommand command)
        {
            if (expression is LambdaExpression)
            {
                var lambdaExpression = expression as LambdaExpression;
                if (lambdaExpression.Body is BinaryExpression)
                {
                    var body = lambdaExpression.Body as BinaryExpression;

                    var stringBuilder = new StringBuilder();

                    stringBuilder.Append(this.ReturnBinaryExpression(database, body, command));

                    return stringBuilder.ToString();
                }
            }
             
            return string.Empty;
        }

        private string ReturnBinaryExpression(Database database, BinaryExpression expression, ICommand command)
        {
            var leftExpression = this.CompileExpression(database, expression.Left, command);
            var rightExpression = this.CompileExpression(database, expression.Right, command);

            return this.Finalize(expression.NodeType, leftExpression, rightExpression);
        }

        private string CompileExpression(Database database, Expression expression, ICommand command)
        {
            if (expression is BinaryExpression)
            {
                return this.ReturnBinaryExpression(database, expression as BinaryExpression, command);
            }
            else
            {
                return this.GetFuncByExpressionType(expression.GetType())(this, database, expression, command);
            }
        }

        private string GenerateExpression(Database database, MemberExpression expression, ICommand command)
        {
            var type = expression.Member.DeclaringType;
            var table = DatabaseMapping.GetInstance().GetTable(type);

            if (table == null)
            {
                if (database.Provider.Generator.IsSqlFunction(expression.Member))
                {
                    return database.Provider.Generator.ReturnSqlFunction(expression.Member);
                }
                else
                {
                    return "1"; // TODO
                }
            }

            var column = table.GetColumnByPropertyInfo(expression.Member as PropertyInfo);

            return string.Format("`{0}`.`{1}`", command.GetAliasByTable(null, table).TableAlias, column.Name);
        }
        private string GenerateExpression(Database database, ConstantExpression expression, ICommand command)
        {
            if (expression.Value == null) return "NULL";

            var value = expression.Value;
            if (value.GetType() == typeof(string) || value.GetType() == typeof(char))
            {
                return string.Format("'{0}'", value.ToString().Replace("'", "\\'"));
            }
            else
            {
                return value.ToString();
            }
        }
        private string GenerateExpression(Database database, ParameterExpression expression, ICommand command)
        {
            throw new NotImplementedException();
        }
        private string GenerateExpression(Database database, UnaryExpression expression, ICommand command)
        {
            var func = this.GetFuncByExpressionType(expression.Operand.GetType());
            if (func != null)
            {
                return func(this, database, expression.Operand, command);
            }

            return "1"; // TODO
        }

        internal string GenerateJoinExpression<T>(Expression expression, Alias alias, SelectCommand<T> command)
            where T : class, new()
        {
            if (expression is LambdaExpression)
            {
                var lambdaExpression = expression as LambdaExpression;
                if (lambdaExpression.Body is BinaryExpression)
                {
                    return this.GenerateJoinExpression<T>(lambdaExpression.Body as BinaryExpression, alias, command);
                }
            }

            throw new Exception("Internal error : the join expression type is unfair.");
        }
        private string GenerateJoinExpression<T>(BinaryExpression expression, Alias alias, SelectCommand<T> command)
            where T : class, new()
        {
            IColumn leftColumn = null, rightColumn = null;

            if (expression.Left is MemberExpression) leftColumn = this.GetColumnByMemberExpression(expression.Left as MemberExpression);
            else if (expression.Left is ParameterExpression) leftColumn = this.GetColumnByParameterExpression(expression.Left as ParameterExpression);

            if (expression.Right is MemberExpression) rightColumn = this.GetColumnByMemberExpression(expression.Right as MemberExpression);
            else if (expression.Right is ParameterExpression) rightColumn = this.GetColumnByParameterExpression(expression.Right as ParameterExpression);

            if (leftColumn == null || rightColumn == null) throw new Exception(string.Format("Expression `{0}` throws an error.", expression.ToString()));

            if (leftColumn.Parent != alias.Table && rightColumn.Parent== alias.Table) // the joined table must be in the left 
            {
                DataExtensions.Exchange(ref leftColumn, ref rightColumn);
            }

            return this.Finalize(
                expression.NodeType, 
                string.Format("`{0}`.`{1}`", command.GetAliasByTable(alias, leftColumn.Parent).TableAlias, leftColumn.Name),
                string.Format("`{0}`.`{1}`", command.GetAliasByTable(alias, rightColumn.Parent).TableAlias, rightColumn.Name));
        }

        private IColumn GetColumnByMemberExpression(MemberExpression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            if (!(expression.Member is PropertyInfo)) throw new Exception("A column must be of type 'PropertyType'");

            var table = DatabaseMapping.GetInstance().GetTable(expression.Member.DeclaringType);
            if (table == null) throw new Exception(string.Format("The type '{0}' is not a table.", expression.Member.DeclaringType.Name));

            var column = table.GetColumnByPropertyInfo(expression.Member as PropertyInfo);
            if (column == null) throw new Exception(string.Format("The member '{0}' is not a column.", expression.Member.Name));

            return column;
        }
        private IColumn GetColumnByParameterExpression(ParameterExpression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            
            var table = DatabaseMapping.GetInstance().GetTable(expression.Type);
            if (table == null) throw new Exception(string.Format("The type '{0}' is not a table.", expression.Type.Name));

            if (table.PrimaryKeys.Count != 1) throw new Exception("TODO");
            return table.PrimaryKeys.Single();
        }

        private string Finalize(ExpressionType type, string leftExpression, string rightExpression)
        {
            var node = string.Empty;
            _expressionsType.TryGetValue(type, out node);

            if(type == ExpressionType.Equal || type == ExpressionType.NotEqual)
            {
                if (rightExpression == "NULL" || leftExpression == "NULL") // remplacement de "<arg> = NULL" par "<arg> IS NULL"
                {
                    node = (type == ExpressionType.Equal ? "IS" : "IS NOT");

                    if (leftExpression == "NULL") // remplacement de "NULL IS <arg>" par "<arg> IS NULL"
                    {
                        var expression = rightExpression;
                        rightExpression = leftExpression;
                        leftExpression = expression;
                    }
                }
            }

            return string.Format("{0} {1} {2}", leftExpression, node, rightExpression);
        }

        private Func<object, Database, Expression, ICommand, string> GetFuncByExpressionType(Type type)
        {
            Func<object, Database, Expression, ICommand, string> func = null;

            var enumerator = this.m_methods.GetEnumerator();
            while (func == null && enumerator.MoveNext())
            {
                var currentType = enumerator.Current.Key;

                if (currentType == type || type.IsSubclassOf(currentType))
                {
                    func = enumerator.Current.Value;
                }
            }

            return func;
        }

        public static ExpressionCompiler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ExpressionCompiler();
            }

            return _instance;
        }
    }
}
