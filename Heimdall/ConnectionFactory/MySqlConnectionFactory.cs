using Heimdall.Domain.Configurations;
using Heimdall.Contract;
using Heimdall.Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Heimdall.ConnectionFactory
{
    internal class MySqlConnectionFactory : ConnectionFactoryBase
    {
        protected override IDbTransaction BeginTransactionInternal(IDbConnection connection, IsolationLevel isolationLevel)
        {
            return (connection as MySqlConnection).BeginTransaction(isolationLevel);
        }

        protected override IDbCommand CreateCommandInternal(string commandText, IDbConnection connection, IDbTransaction transaction)
        {
            var tx = (transaction == null
                ? null
                : transaction as MySqlTransaction);
            return new MySqlCommand(commandText, connection as MySqlConnection, tx);
        }

        protected override IDbDataParameter GetParameterInternal(string name, object value)
        {
            return new MySqlParameter(name, value) as IDbDataParameter;
        }

        protected override IDbConnection OpenConnectionInternal()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = Config.Server;
            sb.Port = (uint)Config.Port;
            sb.UserID = Config.User;
            sb.Password = Config.Password;
            sb.Database = Config.Database;

            try
            {
                MySqlConnection conn = new MySqlConnection(sb.ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionFailedException(ex);
            }
        }
    }
}
