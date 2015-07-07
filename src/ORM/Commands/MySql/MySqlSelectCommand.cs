using sORM.Commands.Expressions;
using sORM.Enums;
using System;
using System.Linq.Expressions;
using System.Text;

namespace sORM.Commands.MySql
{
    public sealed class MySqlSelectCommand<T> : SelectCommand<T>
        where T : class, new()
    {
        // FIELDS

        // PROPERTIES

        // CONSTRUCTORS
        internal MySqlSelectCommand(Database database) 
            : base(database)
        { }
        internal MySqlSelectCommand(Database database, params string[] columns)
            : base(database, columns)
        { }

        // METHODS
        public override SelectCommand<T> Join<T1>(Expression<Func<T1, T, bool>> predicate)
        {
            return base.Join<T1>(predicate);
        }
        public override SelectCommand<T> Join<T1>(JoinTypeEnum type, Expression<Func<T1, T, bool>> predicate)
        {
            if (type == JoinTypeEnum.FULL_JOIN) throw new Exception("No FULL JOIN on MySql.");

            return base.Join<T1>(type, predicate);
        }
        public override SelectCommand<T> Join<T1, T2>(Expression<Func<T1, T2, bool>> predicate)
        {
            return base.Join<T1, T2>(predicate);
        }
        public override SelectCommand<T> Join<T1, T2>(JoinTypeEnum type, Expression<Func<T1, T2, bool>> predicate)
        {
            if (type == JoinTypeEnum.FULL_JOIN) throw new Exception("No FULL JOIN on MySql.");

            return base.Join<T1, T2>(type, predicate);
        }

        public override SelectCommand<T> Compile()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("SELECT ");

            var column = 0;
            for (int i = 0; i < this._aliases.Count; i++)
            {
                var currentAlias = this._aliases[i];

                foreach (var pair in currentAlias.Columns)
                {
                    if (column == 0)
                    {
                        stringBuilder.AppendFormat("`{0}`.`{1}` AS `{2}`", currentAlias.TableAlias, pair.Key.Name, pair.Value);
                    }
                    else
                    {
                        stringBuilder.AppendFormat(",\r\n\t`{0}`.`{1}` AS `{2}`", currentAlias.TableAlias, pair.Key.Name, pair.Value);
                    }

                    column++;
                }
            }

            for (int i = 0; i < this._aliases.Count; i++)
            {
                var currentAlias = this._aliases[i];

                if (i == 0)
                {
                    stringBuilder.AppendFormat("\r\nFROM `{0}` AS `{1}`", currentAlias.Table.Name, currentAlias.TableAlias);
                }
                else
                {
                    this.GenerateJoin(stringBuilder, currentAlias);
                }
            }

            //this.GenerateJoins(stringBuilder);
            this.GenerateWheres(stringBuilder);
            this.GenerateOrderBy(stringBuilder);
            this.GenerateLimit(stringBuilder);

            stringBuilder.Append(';');

            this.m_command = stringBuilder.ToString();

            return this;
        }

        private void GenerateJoin(StringBuilder stringBuilder, Alias alias)
        {
            stringBuilder.AppendFormat("\n{0}", base.m_database.Provider.Fragment.ReturnJoin(base.m_joinExpressions[alias.Join], this, alias, alias.Join));
        }

        private void GenerateJoins(StringBuilder stringBuilder)
        {
            var enumerator = base.m_joinExpressions.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var pair = enumerator.Current;

                stringBuilder.AppendFormat("\n{0}", base.m_database.Provider.Fragment.ReturnJoin(this, null, pair.Value, pair.Key));
            }
        }
        private void GenerateWheres(StringBuilder stringBuilder)
        {
            for (int i = 0; i < base.m_whereExpressions.Count; i++)
            {
                var where = base.m_whereExpressions[i];

                if (i == 0) stringBuilder.Append("\nWHERE ");
                else stringBuilder.Append("\nAND ");

                stringBuilder.Append(ExpressionCompiler.GetInstance().ReturnExpression(base.m_database, where, this));
            }
        }
        private void GenerateOrderBy(StringBuilder stringBuilder)
        {
            if (base.m_orderExpressions.Count > 0)
            {
                stringBuilder.Append("\nORDER BY ");
                foreach (var item in base.m_orderExpressions)
                {
                    stringBuilder.AppendFormat("`{0}` {1}", "c_1", (item.Value == OrderTypeEnum.ORDER_ASC ? "ASC" : "DESC")); // TODO
                }
            }
        }
        private void GenerateLimit(StringBuilder stringBuilder)
        {
            if (this.m_index.HasValue && this.m_count.HasValue)
            {
                if (this.m_index.Value < 0)
                {
                    // TODO : warning message
                }

                if (this.m_count.Value < 0)
                {
                    // TODO : error message
                }
                else
                {
                    stringBuilder.AppendFormat("\n{0}", base.m_database.Provider.Fragment.ReturnLimit(this.m_index.Value, this.m_count.Value));
                }
            }
            else if (this.m_count.HasValue)
            {
                if (this.m_count.Value < 0)
                {
                    // TODO : error message
                }
                else
                {
                    stringBuilder.AppendFormat("\n{0}", base.m_database.Provider.Fragment.ReturnLimit(this.m_count.Value));
                }
            }
        }
    }
}
