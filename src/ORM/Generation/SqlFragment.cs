using sORM.Commands;
using sORM.Enums;
using sORM.Schema.Interfaces;
using System.Linq.Expressions;

namespace sORM.Generation
{
    public abstract class SqlFragment
    {

        // FIELDS

        // PROPERTIES
        public string AutoIncrement { get; internal set; }

        // CONSTRUCTORS 

        // METHODS
        public abstract string ReturnLimit(int count);
        public abstract string ReturnLimit(int index, int count);

        public abstract string ReturnJoin(ICommand command, ITable table, JoinTypeEnum type, Expression condition);
        public abstract string ReturnJoin(ICommand command, ITable table, string aliasTable, JoinTypeEnum type, Expression condition);
        public abstract string ReturnJoin<T>(JoinTypeEnum type, SelectCommand<T> command, Alias alias, Expression predicate) where T : class, new();
    }
}
