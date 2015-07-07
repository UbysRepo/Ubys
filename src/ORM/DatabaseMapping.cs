using sORM.Schema;
using sORM.Schema.Attributes;
using sORM.Schema.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace sORM
{
    public class DatabaseMapping
    {
        // FIELDS
        private static DatabaseMapping _instance;

        private readonly List<Type> m_cachedTypes;
        private readonly Dictionary<Type, ITable> m_tables;

        // PROPERTIES
        public int TablesCount { get { return this.m_tables.Count; } }

        // CONSTRUCTORS
        private DatabaseMapping()
        {
            this.m_cachedTypes = new List<Type>();
            this.m_tables = new Dictionary<Type, ITable>();
        }

        // METHODS
        public void LoadAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                this.LoadType(types[i]);
            }
        }

        public void CreateTables(Database database)
        {
            foreach (var item in this.m_tables) item.Value.VerifyTable(database.Provider);
            foreach (var item in this.GetTables())
            {
                var command = database.Provider.Generator.CreateTable(database.Provider, item);

                database.ExecuteNonQuery(command);
            }
        }

        public void LoadType(Type type)
        {
            if (!this.m_cachedTypes.Contains(type))
            {
                this.m_cachedTypes.Add(type);

                if (type.GetCustomAttribute(typeof(TableAttribute), false) != null)
                {
                    this.m_tables.Add(type, new Table(type));
                }
            }
        }

        internal ITable GetTable(Type type)
        {
            if (!this.m_tables.ContainsKey(type))
            {
                this.LoadType(type);
            }

            if (!this.m_tables.ContainsKey(type))
            {
                return null;
            }

            return this.m_tables[type];
        }
        internal ITable[] GetTables() // TODO : refaire
        {
            var tables = new List<ITable>();

            foreach (var item in this.m_tables)
            {
                var table = item.Value;
                if (table.ForeignKeys.Count > 0)
                {
                    for (int i = 0; i < table.ForeignKeys.Count; i++)
                    {
                        var foreignTable = table.ForeignKeys[i].GetForeignKey().ForeignTable;

                        if (!tables.Contains(foreignTable))
                        {
                            tables.Add(foreignTable);
                        }
                    }
                }

                if (!tables.Contains(table))
                {
                    tables.Add(table);
                }
            }

            return tables.ToArray();
        }

        public static DatabaseMapping GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseMapping();
            }

            return _instance;
        }
    }
}
