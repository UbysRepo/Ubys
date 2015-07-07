using sORM.Generation;
using System;
using System.Data;

namespace sORM.Providers.MySql
{
    public class MySqlGenerator : SqlGenerator
    {
        // FIELDS
        private Database m_database;

        // PROPERTIES

        // CONSTRUCTORS
        public MySqlGenerator(Database database)
        {
            this.m_database = database;
        }

        // METHODS
        protected override void Initialize()
        {
            base.m_members.Add(base.GetMember(typeof(DateTime), "Now"), "NOW()");
        }

        public override string GetNativeType(DbType sqlType)
        {
            switch (sqlType)
            {
                case DbType.VarNumeric:
                case DbType.Single:
                case DbType.Currency:
                    return "NOT SUPPORTED";
                case DbType.Time:
                    return "TIME";
                case DbType.Date:
                    return "DATE";
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.DateTimeOffset:
                    return "DATETIME";
                case DbType.Object:
                case DbType.AnsiString:
                case DbType.String:
                    return "VARCHAR";
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    return "CHAR";
                case DbType.Binary:
                    return "BLOB";
                case DbType.SByte:
                    return "TINYINT";
                case DbType.Byte:
                    return "TINYINT UNSIGNED";
                case DbType.Int16:
                    return "SMALLINT";
                case DbType.Int32:
                    return "INT";
                case DbType.Int64:
                    return "BIGINT";
                case DbType.UInt16:
                    return "SMALLINT UNSIGNED";
                case DbType.UInt32:
                    return "INT UNSIGNED";
                case DbType.UInt64:
                    return "BIGINT UNSIGNED";
                case DbType.Double:
                    return "DOUBLE";
                case DbType.Decimal:
                    return "DECIMAL";
                case DbType.Boolean:
                    return "BOOLEAN";
                case DbType.Guid:
                    return "CHAR(36)";
                case DbType.Xml: // MySql do not support xml type
                    return "TEXT";
                default:
                    return "nvarchar";
            }
        }
    }
}
