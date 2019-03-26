using Heimdall.Contract;
using Heimdall.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heimdall.DomainStorageServices.Contracts
{
    internal abstract class StorageServiceBase
    {
        private static IList<string> tablesChecked = new List<string>();

        protected bool TableExists()
        {
            if (string.IsNullOrEmpty(tableName))
                throw new InvalidOperationException("Tablename not specified");

            bool tableChecked = tablesChecked.Any(t => t.Equals(tableName));
            if (tableChecked)
                return true;

            try
            {
                string sql = $"select count(*) from {tableName}";
                ConnectionFactory.OpenConnection();
                ConnectionFactory.CreateCommand(sql);
                ConnectionFactory.ExecuteCommand();
                ConnectionFactory.CloseConnection();
                tablesChecked.Add(tableName);
                return true;
            }
            catch (Exception ex)
            {
                ConnectionFactory.CloseConnection();
                return false;
            }
        }

        protected internal ConnectionFactoryBase ConnectionFactory { get; private set; }

        protected internal abstract string GetTableCreationScript();

        internal void CreateTableIfNotExists()
        {
            try
            {
                bool tableExists = TableExists();
                if (tableExists)
                    return;

                string sql = GetTableCreationScript();
                ConnectionFactory.OpenConnection();
                ConnectionFactory.CreateCommand(sql);
                ConnectionFactory.ExecuteCommand();
                ConnectionFactory.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        private string tableName;
        protected void SetTableName(string tableName)
        {
            this.tableName = tableName;
            CreateTableIfNotExists();
        }

        public StorageServiceBase()
        {
            ConnectionFactory = HeimdallConfiguration.Instance.Database.ConnectionFactory;
        }
    }
}
