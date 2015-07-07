using System;

namespace sORM.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        // FIELDS
        public string Name { get; private set; }

        // PROPERTIES

        // CONSTRUCTORS
        public ColumnAttribute(string name)
        {
            this.Name = name;
        }

        // METHODS
    }
}
