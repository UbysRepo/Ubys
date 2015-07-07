using System;

namespace sORM.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        // FIELDS

        // PROPERTIES
        public string Name { get; private set; }

        // CONSTRUCTORS
        public TableAttribute(string name)
        {
            this.Name = name;
        }

        // METHODS
    }
}
