using sORM.Cache.Interfaces;
using sORM.Schema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sORM.Cache
{
    public class CacheFactory
    {
        // FIELDS
        private static CacheFactory _instance;

        private readonly Dictionary<ITable, ICache> m_caches;

        // PROPERTIES

        // CONSTRUCTORS
        private CacheFactory()
        {
            this.m_caches = new Dictionary<ITable, ICache>();
        }

        // METHODS
        internal ICache GetCacheByTable(ITable table)
        {
            if (!this.m_caches.ContainsKey(table))
            {
                this.m_caches.Add(table, new DefaultCache(table));
            }

            return this.m_caches[table];
        }

        public static CacheFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CacheFactory();
            }

            return _instance;
        }
    }
}
