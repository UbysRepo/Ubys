using sORM.Schema.Interfaces;
using System;

namespace sORM.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PrimaryKeyAttribute : Attribute
    {
        // FIELDS

        // PROPERTIES
        public string ColumnName { get; private set; }
        public bool AutoIncrement { get; private set; }

        internal IColumn Column { get; set; }

        // CONSTRUCTORS
        public PrimaryKeyAttribute()
        {

        }
        public PrimaryKeyAttribute(string columnName)
        {
            this.ColumnName = columnName;
            this.AutoIncrement = true;
        }
        public PrimaryKeyAttribute(bool autoIncrement)
        {
            this.AutoIncrement = autoIncrement;
        }
        public PrimaryKeyAttribute(string columnName, bool autoIncrement)
        {
            this.ColumnName = columnName;
            this.AutoIncrement = autoIncrement;
        }

        // METHODS
        internal void Initialize()
        { }
    }
}
