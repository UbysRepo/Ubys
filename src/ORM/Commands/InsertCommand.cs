using sORM.Schema.Interfaces;
using System;

namespace sORM.Commands
{
    public class InsertCommand<T> : ICommand
        where T : class, new()
    {
        // FIELDS
        protected readonly Database m_database;

        protected readonly T[] m_elements;

        // PROPERTIES

        // CONSTRUCTORS
        public InsertCommand(Database database, params T[] elements)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (elements == null) throw new ArgumentNullException("elements");
            if (elements.Length == 0) throw new ArgumentException("elements");

            this.m_database = database;
        }

        // METHODS

        public Alias GetAliasByTable(Alias alias, ITable table)
        {
            throw new NotImplementedException();
        }
    }
}
