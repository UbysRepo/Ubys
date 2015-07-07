using System;

namespace sORM.Commands
{
    public class CommandArgument
    {
        // FIELDS
        private readonly string m_name;
        private readonly object m_value;

        // PROPERTIES
        public string Name { get { return this.m_name; } }

        // CONSTRUCTORS
        public CommandArgument(string name, object value)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (value == null) throw new ArgumentNullException("value");

            if (!name.StartsWith("@")) name = string.Format("@{0}", name);

            this.m_name = name;
            this.m_value = value;
        }

        // METHODS
        public string ReturnValue()
        {
            return string.Format("'{0}'", this.m_value);
        }
    }
}
