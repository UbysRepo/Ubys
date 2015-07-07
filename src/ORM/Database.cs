using sORM.Commands;
using sORM.Providers;
using sORM.Providers.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace sORM
{
    /// <summary>
    /// Merci a DevMDamien https://github.com/DevMDamien/sORM
    /// </summary>
    public class Database
    {
        // FIELDS
        private readonly DatabaseConfiguration m_configuration;
        private readonly SemaphoreSlim m_semaphore;

        private DbProviderFactory m_factory;
        private DbConnection m_connection;

        private DataProvider m_provider;

        public event Action<string> executingRequestLog;

        // PROPERTIES
        public DataProvider Provider { get { return this.m_provider; } }

        // CONSTRUCTORS
        public Database(DatabaseConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.m_configuration = configuration;
            this.m_semaphore = new SemaphoreSlim(1, 1);

            this.m_provider = new MySqlDataProvider(this); // TODO

            this.Initialize();
        }

        // METHODS
        private void Initialize()
        {
            if (!string.IsNullOrWhiteSpace(this.m_configuration.ProviderName))
            {
                this.m_factory = DbProviderFactories.GetFactory(this.m_configuration.ProviderName);
            }

            //throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            if (this.m_connection != null)
            {
                this.CloseConnection();
            }

            this.m_connection = this.m_factory.CreateConnection();
            this.m_connection.ConnectionString = this.m_configuration.GetConnectionString();
            this.m_connection.Open();
        }

        public void CloseConnection()
        {
            this.m_connection.Close();
            this.m_connection.Dispose();
            this.m_connection = null;
        }

        private IDbCommand CreateCommand(string sqlCommand)
        {
            if (string.IsNullOrWhiteSpace(sqlCommand)) throw new ArgumentNullException("sqlCommand");

            var command = this.m_connection.CreateCommand();
            command.CommandText = sqlCommand;

            if (this.executingRequestLog != null)
            {
                try { this.executingRequestLog(sqlCommand + "\r\n"); }
                finally { }
            }

            return command;
        }

        public IEnumerable<IDataReader> ExecuteRead(string sqlCommand)
        {
            var command = this.CreateCommand(sqlCommand);

            this.m_semaphore.Wait();
            try
            {

                var reader = command.ExecuteReader();

                var values = new object[reader.FieldCount];
                while (reader.Read())
                {
                    yield return reader;
                }

                reader.Close();
            }
            finally
            {
                this.m_semaphore.Release();
            }

            yield break;
        }

        public object ExecuteScarlar(string sqlCommand)
        {
            var command = this.CreateCommand(sqlCommand);
            object value = null;

            this.m_semaphore.Wait();
            try
            {
                value = command.ExecuteScalar();
            }
            finally
            {
                this.m_semaphore.Release();
            }

            return value;
        }

        public void ExecuteNonQuery(string sqlCommand)
        {
            var command = this.CreateCommand(sqlCommand);

            this.m_semaphore.Wait();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                this.m_semaphore.Release();
            }
        }
    }
}
