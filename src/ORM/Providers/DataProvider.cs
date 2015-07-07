using sORM.Commands;
using sORM.Generation;

namespace sORM.Providers
{
    public abstract class DataProvider
    {
        // FIELDS
        protected SqlFragment m_fragment;
        protected SqlGenerator m_generator;

        // PROPERTIES
        public SqlFragment Fragment { get { return this.m_fragment; } }
        public SqlGenerator Generator { get { return this.m_generator; } }

        // CONSTRUCTORS
        public DataProvider()
        { }

        // METHODS
        public abstract SelectCommand<T> Select<T>(Database database) where T : class, new();
        public abstract SelectCommand<T> Select<T>(Database database, params string[] columns) where T : class, new();

        public abstract InsertCommand<T> Insert<T>(Database database, params T[] elements) where T : class, new();
    }
}
