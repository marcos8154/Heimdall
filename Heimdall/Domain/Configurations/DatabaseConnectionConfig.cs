using Heimdall.ConnectionFactory;
using Heimdall.Contract;

namespace Heimdall.Domain.Configurations
{
    public class DatabaseConnectionConfig
    {
        internal ConnectionFactoryBase ConnectionFactory { get; private set; }
        public void UseMySQL(string server, int port, string user,
            string password, string database)
        {
            DatabaseType = DatabaseType.MySQL;
            Server = server;
            Port = port;
            User = user;
            Password = password;
            Database = database;
            ConnectionFactory = new MySqlConnectionFactory();
        }

        public string GetDbVendor()
        {
            switch (DatabaseType)
            {
                case DatabaseType.FirebirdSQL: return "FirebirdSQL";
                case DatabaseType.MSSQL: return "SQL Server";
                case DatabaseType.MySQL: return "MySQL";
                case DatabaseType.PostgreSQL: return "PostgreSQL";
                default: return "Undefined";
            }
        }

        public void UsePostgreSQL(string server, int port, string user,
              string password, string database)
        {
            DatabaseType = DatabaseType.PostgreSQL;
            Server = server;
            Port = port;
            User = user;
            Password = password;
            Database = database;
            ConnectionFactory = new PgSqlConnectionFactory();
        }

        public void UseFirebirdSQL(string server, int port, string user,
         string password, string database)
        {
            DatabaseType = DatabaseType.FirebirdSQL;
            Server = server;
            Port = port;
            User = user;
            Password = password;
            Database = database;
            ConnectionFactory = new FbSqlConnectionFactory();
        }

        public void UseSQLServer(string datasource, string user,
             string password, string initialCatalog)
        {
            DatabaseType = DatabaseType.MSSQL;
            Server = datasource;
            User = user;
            Password = password;
            Database = initialCatalog;
            ConnectionFactory = new SqlServerConnectionFactory();
        }

        internal DatabaseType DatabaseType { get; private set; }
        internal string Server { get; private set; }
        internal int Port { get; private set; }
        internal string User { get; private set; }
        internal string Password { get; private set; }
        internal string Database { get; private set; }
    }
}
