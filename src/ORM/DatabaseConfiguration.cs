namespace sORM
{
    public class DatabaseConfiguration
    {
        // FIELDS

        // PROPERTIES
        public string ProviderName { get; set; }

        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

        // CONSTRUCTORS
        public DatabaseConfiguration()
        { }
        public DatabaseConfiguration(string host, string port, string user, string password, string databaseName, string providerName)
        {
            this.ProviderName = providerName;

            this.Host = host;
            this.Port = port;
            this.User = user;
            this.Password = password;
            this.DatabaseName = databaseName;
        }

        // METHODS
        public string GetConnectionString()
        {
            return string.Format("Database={0};Server={1};Port={2};Uid={3};Pwd={4};", this.DatabaseName, this.Host, this.Port, this.User, this.Password);
        } 
    }
}
