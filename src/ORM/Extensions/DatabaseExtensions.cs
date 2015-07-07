using sORM.Commands;
using sORM.Commands.MySql;

namespace sORM.Extensions
{
    public static class DatabaseExtensions
    {
        public static SelectCommand<T> Select<T>(this Database database)
            where T : class, new()
        {
            return database.Provider.Select<T>(database);
        }
        public static SelectCommand<T> Select<T>(this Database database, params string[] columns)
            where T : class, new()
        {
            return database.Provider.Select<T>(database, columns);
        }

        public static InsertCommand<T> Insert<T>(this Database database, params T[] elements)
            where T : class, new()
        {
            return database.Provider.Insert<T>(database, elements);
        }
    }
}
