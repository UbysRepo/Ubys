using sORM.Cache;
using sORM.Enums;
using sORM.Schema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace sORM.Commands
{
    public abstract class SelectCommand<T> : ICommand
        where T : class, new()
    {
        // FIELDS
        private int m_columnId = 0;
        private int m_tableId = 0;

        protected readonly ITable m_table;
        internal readonly List<Alias> _aliases;

        protected readonly Database m_database;
        protected readonly List<Expression> m_whereExpressions;
        protected readonly Dictionary<Expression, JoinTypeEnum> m_joinExpressions;
        protected readonly Dictionary<Expression, OrderTypeEnum> m_orderExpressions;
        
        protected int? m_index;
        protected int? m_count;

        protected string m_command;

        // PROPERTIES

        // CONSTRUCTORS
        protected SelectCommand(Database database) 
            : this(database, DatabaseMapping.GetInstance().GetTable(typeof(T)))
        { }
        protected SelectCommand(Database database, params string[] columns)
            : this(database, DatabaseMapping.GetInstance().GetTable(typeof(T)), columns)
        { }

        private SelectCommand(Database database, ITable table)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (table == null) throw new ArgumentNullException("table");

            this.m_whereExpressions = new List<Expression>();
            this.m_joinExpressions = new Dictionary<Expression, JoinTypeEnum>();
            this.m_orderExpressions = new Dictionary<Expression, OrderTypeEnum>();

            this.m_database = database;
            this.m_table = table;

            this._aliases = new List<Alias> { new Alias(this.m_table, ref this.m_tableId, ref this.m_columnId) };

            this.Initialize();
        }
        private SelectCommand(Database database, ITable table, params string[] columns)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (table == null) throw new ArgumentNullException("table");
            if (columns == null) throw new ArgumentNullException("columnse");

            this.m_whereExpressions = new List<Expression>();
            this.m_joinExpressions = new Dictionary<Expression, JoinTypeEnum>();
            this.m_orderExpressions = new Dictionary<Expression, OrderTypeEnum>();

            this.m_database = database;
            this.m_table = table;

            this._aliases = new List<Alias> { new Alias(this.m_table, ref this.m_tableId, ref this.m_columnId) };

            this.Initialize();
        }

        // METHODS
        private void Initialize()
        { }

        private void AddWhereExpression(Expression expression)
        {
            this.m_whereExpressions.Add(expression);
        }
        private void AddJoinExpression(JoinTypeEnum type, Expression expression)
        {
            this.m_joinExpressions.Add(expression, type);
        }
        private void AddOrderByExpression(OrderTypeEnum type, Expression expression)
        {
            this.m_orderExpressions.Add(expression, type);
        }

        public SelectCommand<T> Where(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            this.AddWhereExpression(predicate);

            return this;
        }
        public SelectCommand<T> Where<T1>(Expression<Func<T1, bool>> predicate)
            where T1 : class, new()
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            this.AddWhereExpression(predicate);

            return this;
        }
        public SelectCommand<T> Where<T1, T2>(Expression<Func<T1, T2, bool>> predicate)
            where T1 : class, new()
            where T2 : class, new()
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            this.AddWhereExpression(predicate);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Table joint</typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual SelectCommand<T> Join<T1>(Expression<Func<T1, T, bool>> predicate)
            where T1 : class, new()
        {
            return this.Join<T1>(JoinTypeEnum.LEFT_JOIN, predicate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Table joint</typeparam>
        /// <typeparam name="T2">Table permettant de créer le predicate</typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual SelectCommand<T> Join<T1, T2>(Expression<Func<T1, T2, bool>> predicate)
            where T1 : class, new()
            where T2 : class, new()
        {
            return this.Join(JoinTypeEnum.LEFT_JOIN, predicate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Table joint</typeparam>
        /// <param name="type">Type de la jointure</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual SelectCommand<T> Join<T1>(JoinTypeEnum type, Expression<Func<T1, T, bool>> predicate)
            where T1 : class, new()
        {
            if (type < JoinTypeEnum.LEFT_JOIN || type > JoinTypeEnum.FULL_JOIN) throw new ArgumentException("type");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var table = DatabaseMapping.GetInstance().GetTable(typeof(T1));
            if (table == null) throw new Exception(string.Format("'{0}' is not a table.", typeof(T1)));

            this._aliases.Add(new Alias(predicate, table, ref this.m_tableId, ref this.m_columnId));
            this.AddJoinExpression(type, predicate);

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Table joint</typeparam>
        /// <typeparam name="T2">Table permettant de créer le predicate</typeparam>
        /// <param name="type">Type de la jointure</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual SelectCommand<T> Join<T1, T2>(JoinTypeEnum type, Expression<Func<T1, T2, bool>> predicate) 
            where T1 : class, new() 
            where T2 : class, new()
        {
            if (type < JoinTypeEnum.LEFT_JOIN || type > JoinTypeEnum.FULL_JOIN) throw new ArgumentException("type");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var table = DatabaseMapping.GetInstance().GetTable(typeof(T1));
            if (table == null) throw new Exception(string.Format("'{0}' is not a table.", typeof(T1)));

            this._aliases.Add(new Alias(predicate, table, ref this.m_tableId, ref this.m_columnId));
            this.AddJoinExpression(type, predicate);

            return this;
        }

        public SelectCommand<T> OrderBy(IColumn column)
        {
            if (column == null) throw new ArgumentNullException("column");

            throw new NotImplementedException();
        }
        public SelectCommand<T> OrderBy(Expression<Func<T, object>> property)
        {
            if (property == null) throw new ArgumentNullException("property");

            this.AddOrderByExpression(OrderTypeEnum.ORDER_ASC, property);

            return this;
        }
        public SelectCommand<T> OrderBy(Expression<Func<T, object>> property, OrderTypeEnum type)
        {
            if (property == null) throw new ArgumentNullException("property");
            if (type < OrderTypeEnum.ORDER_ASC || type > OrderTypeEnum.ORDER_DESC) throw new ArgumentException("type");

            this.AddOrderByExpression(type, property);

            return this;
        }

        public Alias GetAliasByTable(Alias alias, ITable table)
        {
            if (alias != null && alias.Table == table)
            {
                return alias;
            }
            else
            {
                return this._aliases.FirstOrDefault(entry => entry.Table == table);
            }
        }

        public SelectCommand<T> Limit(int count)
        {
            this.m_count = count;

            return this;
        }
        public SelectCommand<T> Limit(int index, int count)
        {
            this.m_index = index;
            this.m_count = count;

            return this;
        }

        public abstract SelectCommand<T> Compile();

        public IEnumerable<T> Query()
        {
            this.Compile();

            return this.Query(this.m_command);
        }
        public IEnumerable<T> Query(params CommandArgument[] arguments)
        {
            if (arguments == null || arguments.Length == 0) return this.Query();

            return this.Query(this.ReturnCommand(arguments));
        }
        /*
        public IEnumerable<T> Query(Func<object[], T> func)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<T> Query(Func<object[], T> func, params CommandArgument[] arguments)
        {
            if (arguments == null || arguments.Length == 0) return this.Query(func);

            throw new NotImplementedException();
        }
        */

        protected IEnumerable<T> Query(string command)
        {
            foreach (var item in this.m_database.ExecuteRead(command))
            {
                T element = null;

                for (int i = 0; i < this._aliases.Count; i++)
                {
                    var alias = this._aliases[i];

                    if (alias.CanCacheInstance()) // retrouver l'instance ou la créer + mettre en cache
                    {
                        var cache = CacheFactory.GetInstance().GetCacheByTable(alias.Table);

                        element = cache.GetInstanceByPrimaryKeys<T>(item, alias);
                        foreach (var pair in alias.Columns)
                        {
                            if (!pair.Key.IsPrimaryKey)
                            {
                                if (pair.Key.IsForeignKey) // TODO
                                {
                                    var foreignTable = DatabaseMapping.GetInstance().GetTable(pair.Key.GetColumnType());
                                    if (foreignTable != null)
                                    {
                                        var foreignCache = CacheFactory.GetInstance().GetCacheByTable(foreignTable);

                                        pair.Key.FromSqlData(element, foreignCache.GetForeignInstance(item, pair.Key.GetForeignKey(), pair.Value));
                                    }
                                    else
                                    {
                                        pair.Key.FromSqlData(element, item[pair.Value]);
                                    }
                                }
                                else
                                {
                                    pair.Key.FromSqlData(element, item[pair.Value]);
                                }
                            }
                        }
                    }
                    else
                    {
                        element = new T();
                        foreach (var pair in alias.Columns)
                        {
                            pair.Key.FromSqlData(element, item[pair.Value]);
                        }
                    }
                }

                yield return element;
            }

            yield break;
        }

        /*
        public IEnumerable<T> Query<T2>(Func<T, T2, T> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            throw new NotImplementedException();
        }
        */
        public T Single()
        {
            return this.Query()
                .Single();
        }
        public T Single(params CommandArgument[] arguments)
        {
            return this.Query(arguments)
                .Single();
        }
        public T SingleOrDefault()
        {
            return this.Query()
                .SingleOrDefault();
        }
        public T SingleOrDefault(params CommandArgument[] arguments)
        {
            return this.Query(arguments)
                .SingleOrDefault();
        }

        public string ReturnCommand()
        {
            if (string.IsNullOrWhiteSpace(this.m_command))
            {
                this.Compile();

                if (string.IsNullOrWhiteSpace(this.m_command)) throw new Exception("The command can not be compiled.");
            }

            return this.m_command;
        }
        public string ReturnCommand(params CommandArgument[] arguments)
        {
            var command = this.ReturnCommand();

            for (int i = 0; i < arguments.Length; i++)
            {
                var arg = arguments[i];

                var index = command.IndexOf(arg.Name);
                if (index == -1) throw new Exception(string.Format("No argument named '{0}' in '{1}'.", arg.Name, this.m_command));

                command = command.Remove(index - 1, arg.Name.Length + 2) // enlever les quotes
                    .Insert(index - 1, arg.ReturnValue());
            }

            return command;
        }
    }

    public class Alias
    {
        // FIELDS

        // PROPERTIES
        public ITable Table { get; private set; }
        public string TableAlias { get; private set; }
        public Dictionary<IColumn, string> Columns { get; private set; }
        public int MinIndex { get; private set; }
        public int MaxIndex { get; private set; }

        public Expression Join { get; private set; }

        // CONSTRUCTORS
        internal Alias(ITable table, ref int tableIndex, ref int columnIndex)
        {
            this.Table = table;
            this.Columns = new Dictionary<IColumn, string>();

            this.TableAlias = string.Format("t_{0}", ++tableIndex);

            this.Initialize(ref columnIndex);
        }
        internal Alias(ITable table, string[] columns, ref int tableIndex, ref int columnIndex)
        {
            this.Table = table;
            this.Columns = new Dictionary<IColumn, string>();

            this.TableAlias = string.Format("t_{0}", ++tableIndex);

            this.Initialize(columns, ref columnIndex);
        }
        internal Alias(Expression join, ITable table, ref int tableIndex, ref int columnIndex)
        {
            this.Table = table;
            this.Columns = new Dictionary<IColumn, string>();

            this.TableAlias = string.Format("t_{0}", ++tableIndex);
            this.Join = join;

            this.Initialize(ref columnIndex);
        }
        internal Alias(Expression join, ITable table, string[] columns, ref int tableIndex, ref int columnIndex)
        {
            this.Table = table;
            this.Columns = new Dictionary<IColumn, string>();

            this.TableAlias = string.Format("t_{0}", ++tableIndex);
            this.Join = join;

            this.Initialize(columns, ref columnIndex);
        }

        // METHODS
        private void Initialize(ref int columnIndex)
        {
            this.MinIndex = columnIndex;

            for (int i = 0; i < this.Table.Columns.Count; i++)
            {
                this.Columns.Add(this.Table.Columns[i], string.Format("c_{0}", ++columnIndex));
            }

            this.MaxIndex = columnIndex;
        }
        private void Initialize(string[] columns, ref int columnIndex)
        {
            this.MinIndex = columnIndex;

            for (int i = 0; i < columns.Length; i++)
            {
                var column = this.Table.GetColumnByName(columns[i]);
                if (column != null)
                {
                    this.Columns.Add(column, string.Format("c_{0}", ++columnIndex));
                }
            }

            this.MaxIndex = columnIndex;
        }

        public bool CanCacheInstance()
        {
            return this.Table.PrimaryKeys.Count > 0 && this.Table.PrimaryKeys.All(entry => this.Columns.ContainsKey(entry));
        }
    }
}
