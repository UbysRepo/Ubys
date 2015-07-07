using System;
using sORM.Commands;
using sORM.Enums;
using sORM.Commands.MySql;

namespace sORM.Providers.MySql
{
    public class MySqlDataProvider : DataProvider
    {
        // FIELDS
        private Database m_database;

        // PROPERTIES
        public DatabaseTypeEnum DatabaseType { get { return DatabaseTypeEnum.MYSQL; } }
        
        // CONSTRUCTORS
        public MySqlDataProvider(Database database)
        {
            this.m_database = database;

            base.m_fragment = new MySqlFragment(this.m_database);
            base.m_generator = new MySqlGenerator(this.m_database);
        }

        // METHODS
        public override SelectCommand<T> Select<T>(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");

            return new MySqlSelectCommand<T>(database);
        }

        public override SelectCommand<T> Select<T>(Database database, params string[] columns)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (columns == null) throw new ArgumentNullException("columns");

            return new MySqlSelectCommand<T>(database, columns);
        }

        public override InsertCommand<T> Insert<T>(Database database, params T[] elements)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (elements == null) throw new ArgumentNullException("elements");

            return new MySqlInsertCommand<T>(database, elements);
        }
    }
}
