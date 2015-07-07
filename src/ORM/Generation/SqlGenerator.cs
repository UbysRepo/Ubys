using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Data;
using sORM.Providers;
using sORM.Schema.Interfaces;
using System.Text;

namespace sORM.Generation
{
    public abstract class SqlGenerator
    {
        // FIELDS
        private static readonly Dictionary<Type, DbType> _types = new Dictionary<Type, DbType>
        {
            { typeof(byte), DbType.Byte },
            { typeof(sbyte), DbType.SByte },
            { typeof(short), DbType.Int16 },
            { typeof(ushort), DbType.UInt16 },
            { typeof(int), DbType.Int32 },
            { typeof(uint), DbType.UInt32 },
            { typeof(long), DbType.Int64 },
            { typeof(ulong), DbType.UInt64 },
            { typeof(float), DbType.Single },
            { typeof(double), DbType.Double },
            { typeof(decimal), DbType.Decimal },
            { typeof(bool), DbType.Boolean },
            { typeof(string), DbType.String },
            { typeof(char), DbType.StringFixedLength },
            { typeof(Guid), DbType.Guid },
            { typeof(TimeSpan), DbType.Time },
            { typeof(DateTime), DbType.DateTime },
            { typeof(DateTimeOffset), DbType.DateTimeOffset },
            //{ typeof(Xml), DbType.Xml },
            { typeof(byte[]), DbType.Binary },
            //{ typeof(Enum), DbType.Int32 }
        };

        protected readonly Dictionary<MemberInfo, string> m_members;

        // PROPERTIES

        // CONSTRUCTORS
        public SqlGenerator()
        {
            this.m_members = new Dictionary<MemberInfo, string>();

            this.Initialize();
        }

        // METHODS
        protected abstract void Initialize();

        public abstract string GetNativeType(DbType sqlType);

        public virtual DbType GetDbType(Type type)
        {
            if (_types.ContainsKey(type))
            {
                return _types[type];
            }
            else if (type.IsEnum)
            {
                return DbType.Int32;
            }

            return DbType.Object; // default type
        }

        public string CreateTable(DataProvider provider, ITable table)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            if (table == null) throw new ArgumentNullException("table");

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}`(\r\n", table.Name);
            stringBuilder.Append(this.BuildColumnsCreation(provider, table));
            stringBuilder.Append("\r\n);");

            return stringBuilder.ToString();
        }

        protected virtual string BuildColumnsCreation(DataProvider provider, ITable table)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                var column = table.Columns[i];

                if (i > 0) stringBuilder.Append(",\r\n");

                stringBuilder.AppendFormat("  `{0}` {1}", column.Name, this.BuildColumnAttributes(provider, column));

                if (column.Size.HasValue) stringBuilder.AppendFormat("({0})", column.Size.Value);
                if (!column.Nullable) stringBuilder.Append(" NOT NULL");
            }

            if (table.PrimaryKeys.Count > 0)
            {
                stringBuilder.AppendFormat(",\r\n  PRIMARY KEY (`{0}`)", string.Join("`, `", table.PrimaryKeys.Select(entry => entry.Name)));
            }


            for (int i = 0; i < table.ForeignKeys.Count; i++)
            {
                var column = table.ForeignKeys[i];

                var foreignKey = column.GetForeignKey();

                stringBuilder.AppendFormat(",\r\n  FOREIGN KEY (`{0}`) REFERENCES `{1}`(`{2}`)", column.Name, foreignKey.ForeignTable.Name, foreignKey.ForeignColumn.Name);
            }

            return stringBuilder.ToString();
        }

        protected virtual string BuildColumnAttributes(DataProvider provider, IColumn column)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(this.GetNativeType(column.DbType));
            // TODO : defaultValue

            if (column.IsPrimaryKey && column.GetPrimaryKey().AutoIncrement)
            {
                stringBuilder.AppendFormat(provider.Fragment.AutoIncrement);
            }

            return stringBuilder.ToString();
        }

        public void AddMember(MemberInfo member, string value)
        {
            if (!this.m_members.ContainsKey(member))
            {
                this.m_members.Add(member, value);
            }
        }

        public bool IsSqlFunction(MemberInfo member)
        {
            return this.m_members.ContainsKey(member);
        }

        public string ReturnSqlFunction(MemberInfo member)
        {
            if (this.IsSqlFunction(member))
            {
                return this.m_members[member];
            }

            return string.Empty;
        }

        protected MemberInfo GetMember(Type type, string name)
        {
            var member = type.GetMember(name)
                .Single();

            if (member == null) throw new Exception(string.Format("No member named '{0}' in Type {1}.", name, type));

            return member;
        }
    }
}
