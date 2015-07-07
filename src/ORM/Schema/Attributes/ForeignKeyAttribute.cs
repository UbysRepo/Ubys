using sORM.Schema.Interfaces;
using System;
using System.Linq;

namespace sORM.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ForeignKeyAttribute : Attribute
    {
        // FIELDS
        public Type Type { get; private set; }
        public string ColumnName { get; private set; }

        public ITable ForeignTable { get; private set; }
        public IColumn ForeignColumn { get; private set; }

        // PROPERTIES

        // CONSTRUCTORS
        public ForeignKeyAttribute(Type type)
        {
            this.Type = type;
        }
        public ForeignKeyAttribute(Type type, string columnName)
        {
            this.Type = type;
            this.ColumnName = columnName;
        }

        // METHODS
        public void Initialize()
        {
            this.ForeignTable = DatabaseMapping.GetInstance().GetTable(this.Type);
            if (this.ForeignTable == null) throw new Exception(string.Format("The type '{0}' is not a table.", this.Type));

            if (string.IsNullOrEmpty(this.ColumnName))
            {
                if (this.ForeignTable.PrimaryKeys.Count != 1) throw new Exception("You must choice the foreign column because the foreign table don't have only one primary key.");

                this.ForeignColumn = this.ForeignTable.PrimaryKeys.Single();
            }
            else
            {
                this.ForeignColumn = this.ForeignTable.GetColumnByName(this.ColumnName);
                if (this.ForeignColumn == null) throw new Exception(string.Format("No column named '{0}' into the table '{1}'.", this.ColumnName, this.ForeignTable.Name));
            }
        }
    }
}
