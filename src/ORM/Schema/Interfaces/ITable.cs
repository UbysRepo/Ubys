using System.Collections.Generic;
using System.Reflection;
using sORM.Providers;

namespace sORM.Schema.Interfaces
{
    public interface ITable
    {
        string Name { get; }

        IReadOnlyList<IColumn> PrimaryKeys { get; }
        IReadOnlyList<IColumn> ForeignKeys { get; }
        IReadOnlyList<IColumn> Columns { get; }

        IColumn GetColumnByPropertyInfo(PropertyInfo propertyInfo);
        IColumn GetColumnByName(string columnName);
        void VerifyTable(DataProvider provider);
        bool CheckPrimaryKeys(object instance, IDictionary<IColumn, object> keys);
        bool CheckPrimaryKey(object instance, IColumn column, object value);

        object CreateInstance();
    }
}
