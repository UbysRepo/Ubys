using sORM.Schema.Interfaces;
using System;

namespace sORM.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultValueAttribute : Attribute
    {
        // FIELDS

        // PROPERTIES
        public object DefaultValue { get; private set; }

        internal IColumn Column { get; private set; }

        // CONSTRUCTORS
        public DefaultValueAttribute(object defaultValue)
        {
            this.DefaultValue = defaultValue;
        }

        // METHODS
        internal void SetColumn(IColumn column)
        {
            throw new NotImplementedException(); // verifier l'égalité des types                
        }

        public override string ToString()
        {
            return string.Format("[ColumnName={0}|DefaultValue='{1}'|Type={2}]",
                this.Column.Name,
                this.DefaultValue,
                this.DefaultValue.GetType());
        }
    }
}
