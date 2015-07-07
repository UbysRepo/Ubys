using sORM.Schema.Attributes;
using sORM.Schema.Interfaces;
using System;
using System.Reflection;
using System.Data;
using sORM.Providers;
using System.Collections.Generic;
using System.Linq;

namespace sORM.Schema
{
    public class Column : IColumn
    {
        // FIELDS
        private readonly PropertyInfo m_property;

        private PrimaryKeyAttribute m_primaryKey;
        private ForeignKeyAttribute m_foreignKey;

        private bool m_nullable;

        // PROPERTIES
        public ITable Parent { get; private set; }

        public string Name { get; private set; }
        public bool IsPrimaryKey { get { return this.m_primaryKey != null; } }
        public bool IsForeignKey { get { return this.m_foreignKey != null; } }
        public bool Nullable { get { return this.m_nullable; } }

        public DbType DbType { get; private set; }
        public int? Size { get; private set; }


        // CONSTRUCTORS
        internal Column(ITable parent, PropertyInfo property)
        {
            this.m_property = property;

            this.Parent = parent;

            this.Initialize(property);
        }
        internal Column(ITable parent, PropertyInfo property, string columnName)
        {
            this.m_property = property;

            this.Parent = parent;

            this.Initialize(property, columnName);
        }

        // METHODS
        private void Initialize(PropertyInfo property, string name = null)
        {
            var column = property.GetCustomAttribute<ColumnAttribute>(false);

            this.Name = (!string.IsNullOrWhiteSpace(name) ? name : (column != null ? column.Name : property.Name).ToLower());

            this.m_primaryKey = property.GetCustomAttribute<PrimaryKeyAttribute>(false);
            this.m_foreignKey = property.GetCustomAttribute<ForeignKeyAttribute>(false);

            this.m_nullable = this.IsNullable();
        }

        public void Verify(DataProvider provider)
        {
            var type = this.m_property.PropertyType;
            if (this.IsForeignKey && this.m_foreignKey.Type == type)
            {
                if (this.m_foreignKey.ForeignColumn != null)
                {
                    type = this.m_foreignKey.ForeignColumn.GetColumnType();
                }
                else
                {
                    var primaryKeys = this.m_foreignKey.ForeignTable.PrimaryKeys;
                    if (primaryKeys.Count != 1) throw new Exception("TODO EXCEPTION !!!");

                    var primaryKey = primaryKeys[0];
                    type = primaryKey.GetColumnType();
                }
            }

            if (type.IsGenericType && type.GetGenericArguments().Length == 1) // inc. CSV system
            {
                type = type.GetGenericArguments()[0];
            }

            this.DbType = provider.Generator.GetDbType(type);
            switch(this.DbType) // TODO
            {
                case DbType.Object:
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    this.Size = 50;
                    break;
            }
        }

        public bool IsProperty(PropertyInfo property)
        {
            return this.m_property == property;
        }

        public void FromSqlData(object instance, object value)
        {
            if (value == null)
            { }
            else
            {
                if ((value.GetType() == this.m_property.PropertyType) ||
                    (this.m_nullable && this.m_property.PropertyType.GetGenericArguments().SingleOrDefault() == value.GetType()))
                {
                    this.m_property.SetValue(instance, value);
                }
                else
                {
                    if(this.m_nullable)
                    {
                        foreach (var item in this.m_property.PropertyType.GetGenericArguments())
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }
        }

        public string ToSqlData(object instance)
        {
            throw new NotImplementedException();
        }

        private bool IsNullable()
        {
            var type = this.m_property.PropertyType;

            if (!type.IsGenericType) return false;

            var genericType = type.GetGenericTypeDefinition();
            return genericType != null && genericType == typeof(Nullable<>);
        }

        public ForeignKeyAttribute GetForeignKey()
        {
            return this.m_foreignKey;
        }
        public PrimaryKeyAttribute GetPrimaryKey()
        {
            return this.m_primaryKey;
        }

        public Type GetColumnType()
        {
            return this.m_property.PropertyType;
        }

        public object GetColumnValue(object instance)
        {
            return this.m_property.GetValue(instance);
        }
    }
}
