using Heimdall.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Heimdall.Domain.Exceptions;

namespace Heimdall.ConnectionFactory
{
    internal class SqlServerConnectionFactory : ConnectionFactoryBase
    {
        protected override IDbTransaction BeginTransactionInternal(IDbConnection connection, IsolationLevel isolationLevel)
        {
            return (connection as SqlConnection).BeginTransaction(isolationLevel);
        }

        protected override IDbCommand CreateCommandInternal(string commandText, IDbConnection connection, IDbTransaction transaction)
        {
            var tx = (transaction == null
                ? null
                : transaction as SqlTransaction);
            return new SqlCommand(commandText, connection as SqlConnection, tx);
        }

        protected override IDbDataParameter GetParameterInternal(string name, object value)
        {
            return new SqlParameter(name, value) as IDbDataParameter;
        }

        protected override IDbConnection OpenConnectionInternal()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = Config.Server;
            sb.UserID = Config.User;
            sb.Password = Config.Password;
            sb.InitialCatalog = Config.Database;

            try
            {
                SqlConnection conn = new SqlConnection(sb.ConnectionString);
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
