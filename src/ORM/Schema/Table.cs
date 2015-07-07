using sORM.Providers;
using sORM.Schema.Attributes;
using sORM.Schema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace sORM.Schema
{
    public class Table : ITable
    {
        // FIELDS
        private readonly Type m_type;

        private readonly List<IColumn> m_columns;
        private readonly List<IColumn> m_primaryKeys;
        private readonly List<IColumn> m_foreignKeys;

        // PROPERTIES
        public string Name { get; private set; }

        public IReadOnlyList<IColumn> Columns { get { return this.m_columns.AsReadOnly(); } }
        public IReadOnlyList<IColumn> PrimaryKeys { get { return this.m_primaryKeys.AsReadOnly(); } }
        public IReadOnlyList<IColumn> ForeignKeys { get { return this.m_foreignKeys.AsReadOnly(); } }

        // CONSTRUCTORS
        internal Table(Type type)
        {
            this.m_type = type;

            this.m_columns = new List<IColumn>();
            this.m_primaryKeys = new List<IColumn>();
            this.m_foreignKeys = new List<IColumn>();

            this.Initialize(type);
        }

        // METHODS
        private void Initialize(Type type)
        {
            var table = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute), false);
            if (table == null) throw new Exception(string.Format("The type '{0}' is not a table.", type));

            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor == null) throw new Exception(string.Format("The type '{0}' do not have a default constructor.", type));

            this.Name = table.Name;

            var properties = type.GetProperties()
                .Where(entry => entry.GetCustomAttribute(typeof(IgnoreAttribute), false) == null)
                .ToArray();

            for (int i = 0; i < properties.Length; i++)
            {
                string name = null;
                var existedColumn = this.GetColumnByName(properties[i].Name);
                if (existedColumn != null)
                {
                    name = this.GetNextColumnName(existedColumn);
                }

                var column = new Column(this, properties[i], name);

                this.m_columns.Add(column);

                if (column.IsPrimaryKey) this.m_primaryKeys.Add(column);
                if (column.IsForeignKey) this.m_foreignKeys.Add(column);
            }
        }

        public void VerifyTable(DataProvider provider)
        {
            for (int i = 0; i < this.m_foreignKeys.Count; i++)
            {
                var column = this.m_foreignKeys[i];
                var foreignKey = column.GetForeignKey();
                if(foreignKey.ForeignTable == null)
                {
                    foreignKey.Initialize();
                }
            }

            for (int i = 0; i < this.m_columns.Count; i++)
            {
                var column = this.m_columns[i];

                column.Verify(provider);
            }
        }

        public bool CheckPrimaryKey(object instance, IColumn column, object value)
        {
            return value.Equals(column.GetColumnValue(instance));
        }
        public bool CheckPrimaryKeys(object instance, IDictionary<IColumn, object> keys)
        {
            foreach (var pair in keys)
            {
                if (!this.CheckPrimaryKey(instance, pair.Key, pair.Value))
                {
                    return false;
                }
            }

            return true;
        }

        public IColumn GetColumnByPropertyInfo(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");

            return this.m_columns.FirstOrDefault(entry => entry.IsProperty(property));
        }

        public IColumn GetColumnByName(string columnName)
        {
            if (columnName == null) throw new ArgumentNullException("columnName");

            return this.m_columns.FirstOrDefault(entry => entry.Name.Equals(columnName, StringComparison.CurrentCultureIgnoreCase));
        }

        public object CreateInstance()
        {
            return Activator.CreateInstance(this.m_type);
        }

        private string GetNextColumnName(IColumn column)
        {
            if (column == null) throw new ArgumentNullException("column");

            var columnName = column.Name;
            var func = new Func<int, string>(index => string.Format("{0}_{1}", columnName, index));

            var i = 1;
            while (column != null) column = this.GetColumnByName(func(++i));

            return func(i);
        }
    }
}
