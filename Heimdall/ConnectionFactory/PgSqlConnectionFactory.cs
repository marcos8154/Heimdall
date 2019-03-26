using Heimdall.Contract;
using Heimdall.Domain.Exceptions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Heimdall.ConnectionFactory
{
    internal class PgSqlConnectionFactory : ConnectionFactoryBase
    {
        protected override IDbTransaction BeginTransactionInternal(IDbConnection connection, IsolationLevel isolationLevel)
        {
            return (connection as NpgsqlConnection).BeginTransaction(isolationLevel);
        }

        protected override IDbCommand CreateCommandInternal(string commandText, IDbConnection connection, IDbTransaction transaction)
        {
            var tx = (transaction == null
                ? null
                : transaction as NpgsqlTransaction);
            return new NpgsqlCommand(commandText, connection as NpgsqlConnection, tx) as IDbCommand;
        }

        protected override IDbDataParameter GetParameterInternal(string name, object value)
        {
            return new NpgsqlParameter(name, value) as IDbDataParameter;
        }

        protected override IDbConnection OpenConnectionInternal()
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = Config.Server;
            sb.Port = Config.Port;
            sb.Username = Config.User;
            sb.Password = Config.Password;
            sb.Database = Config.Database;

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(sb.ConnectionString);
                conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                throw new DatabaseConnectionFailedException(ex);
            }
        }
    }
}
