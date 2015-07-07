using sORM.Commands;
using System.Data;
using sORM.Schema.Attributes;

namespace sORM.Cache.Interfaces
{
    public interface ICache
    {
        object GetInstanceByPrimaryKeys(IDataReader reader, Alias alias);

        T GetInstanceByPrimaryKeys<T>(IDataReader reader, Alias alias) where T : class, new();

        object GetForeignInstance(IDataReader reader, ForeignKeyAttribute foreignKeyAttribute, string aliasName);

        T GetForeignInstance<T>(IDataReader reader, ForeignKeyAttribute foreignKeyAttribute, string aliasName) where T : class, new();
    }
    public interface ICache<T>
        where T : class, new()
    { }
}
