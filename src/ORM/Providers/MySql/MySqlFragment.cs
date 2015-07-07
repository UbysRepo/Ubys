using System.Linq.Expressions;
using sORM.Enums;
using sORM.Generation;
using sORM.Schema.Interfaces;
using sORM.Commands.Expressions;
using System.Collections.Generic;
using sORM.Commands;
using sORM.Commands.MySql;

namespace sORM.Providers.MySql
{
    public sealed class MySqlFragment : SqlFragment
    {
        // FIELDS
        private static readonly Dictionary<JoinTypeEnum, string> _joinsType = new Dictionary<JoinTypeEnum, string>
        {
            { JoinTypeEnum.LEFT_JOIN, "LEFT" },
            { JoinTypeEnum.INNER_JOIN, "INNER" },
            { JoinTypeEnum.RIGHT_JOIN, "RIGHT" },
            { JoinTypeEnum.FULL_JOIN, "FULL" }
        };

        private readonly Database m_database;

        // PROPERTIES

        // CONSTRUCTORS
        public MySqlFragment(Database database)
        {
            this.m_database = database;
        }

        // METHODS
        public override string ReturnLimit(int count)
        {
            return string.Format("LIMIT {0}", count);
        }
        public override string ReturnLimit(int index, int count)
        {
            return string.Format("LIMIT {0},{1}", index, count);
        }

        public override string ReturnJoin(ICommand command, ITable table, JoinTypeEnum type, Expression condition)
        {
            return string.Format("{0} JOIN `{1}` ON {2}",
                _joinsType[type], 
                "TABLE", 
                ExpressionCompiler.GetInstance().ReturnExpression(this.m_database, condition, command));
        }
        public override string ReturnJoin(ICommand command, ITable table, string aliasTable, JoinTypeEnum type, Expression condition)
        {
            return string.Format("{0} JOIN `{1}` AS `{2}` ON {3}",
                _joinsType[type],
                table.Name,
                aliasTable,
                ExpressionCompiler.GetInstance().ReturnExpression(this.m_database, condition, command));
        }

        public override string ReturnJoin<T>(JoinTypeEnum type, SelectCommand<T> command, Alias alias, Expression predicate)
        {
            return string.Format("{0} JOIN `{1}` AS `{2}` ON {3}",
                _joinsType[type],
                alias.Table.Name,
                alias.TableAlias,
                ExpressionCompiler.GetInstance().GenerateJoinExpression(predicate, alias, command));
        }
    }
}
