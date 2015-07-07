using sORM.Providers;
using sORM.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace sORM.Schema.Interfaces
{
    public interface IColumn
    {
        ITable Parent { get; }

        string Name { get; }
        DbType DbType { get; }

        bool IsPrimaryKey { get; }
        bool IsForeignKey { get; }
        int? Size { get; }
        bool Nullable { get; }

        void FromSqlData(object instance, object value);
        string ToSqlData(object instance);

        bool IsProperty(PropertyInfo property);

        void Verify(DataProvider provider);

        ForeignKeyAttribute GetForeignKey();
        PrimaryKeyAttribute GetPrimaryKey();

        Type GetColumnType();

        object GetColumnValue(object instance);
    }
}
