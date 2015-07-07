using sORM.Schema.Interfaces;

namespace sORM.Commands
{
    public interface ICommand
    {

        Alias GetAliasByTable(Alias alias, ITable table);
    }
}
