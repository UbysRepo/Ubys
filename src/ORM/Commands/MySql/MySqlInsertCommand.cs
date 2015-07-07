using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sORM.Commands.MySql
{
    public class MySqlInsertCommand<T> : InsertCommand<T>
        where T : class, new()
    {
        // FIELDS

        // PROPERTIES

        // CONSTRUCTORS
        public MySqlInsertCommand(Database database, params T[] elements)
            : base(database, elements)
        { }

        // METHODS
    }
}
