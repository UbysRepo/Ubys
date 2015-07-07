using sORM.Cache.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using sORM.Schema.Interfaces;
using sORM.Commands;
using sORM.Schema.Attributes;

namespace sORM.Cache
{
    public class DefaultCache : ICache
    {
        // FIELDS
        private readonly ITable m_table;
        private readonly List<object> m_instances;

        // PROPERTIES

        // CONSTRUCTORS
        internal DefaultCache(ITable table)
        {
            this.m_table = table;
            this.m_instances = new List<object>();
        }

        // METHODS
        public object GetInstanceByPrimaryKeys(IDataReader reader, Alias alias)
        {
            var keys = new Dictionary<IColumn, object>();
            foreach (var pair in alias.Columns)
            {
                if (pair.Key.IsPrimaryKey)
                {
                    keys.Add(pair.Key, reader[pair.Value]); // TODO : changer le type de la valeur
                }
            }

            object instance = this.m_instances
                .FirstOrDefault(entry => alias.Table.CheckPrimaryKeys(entry, keys));

            if (instance == null)
            {
                instance = this.m_table.CreateInstance();
                foreach (var pair in keys)
                {
                    if (pair.Key.IsPrimaryKey)
                    {
                        pair.Key.FromSqlData(instance, keys[pair.Key]);
                    }
                    else
                    {
                        pair.Key.FromSqlData(instance, pair.Value);
                    }
                }

                this.m_instances.Add(instance);
            }

            return instance;
        }
        public T GetInstanceByPrimaryKeys<T>(IDataReader reader, Alias alias)
            where T : class, new()
        {
            return (T)this.GetInstanceByPrimaryKeys(reader, alias);
        }

        public object GetForeignInstance(IDataReader reader, ForeignKeyAttribute foreignKeyAttribute, string aliasName)
        {
            var value = reader[aliasName]; // TODO : changer le type de la valeur 

            object instance = this.m_instances
                .FirstOrDefault(entry => foreignKeyAttribute.ForeignTable.CheckPrimaryKey(entry, foreignKeyAttribute.ForeignColumn, value));

            if (instance == null)
            {
                // TODO : Lazy type
            }

            return instance;
        }

        public T GetForeignInstance<T>(IDataReader reader, ForeignKeyAttribute foreignKeyAttribute, string aliasName) 
            where T : class, new()
        {
            return (T)this.GetForeignInstance(reader, foreignKeyAttribute, aliasName);
        }
    }
}
