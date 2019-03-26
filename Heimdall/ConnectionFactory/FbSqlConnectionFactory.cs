using FirebirdSql.Data.FirebirdClient;
using Heimdall.Contract;
using Heimdall.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Heimdall.ConnectionFactory
{
    internal class FbSqlConnectionFactory : ConnectionFactoryBase
    {
        protected override IDbTransaction BeginTransactionInternal(IDbConnection connection, IsolationLevel isolationLevel)
        {
            return (connection as FbConnection).BeginTransaction(isolationLevel);
        }

        protected override IDbCommand CreateCommandInternal(string commandText, IDbConnection connection, IDbTransaction transaction)
        {
            var tx = (transaction == null
                ? null
                : transaction as FbTransaction);
            return new FbCommand(commandText, connection as FbConnection, tx);
        }

        protected override IDbDataParameter GetParameterInternal(string name, object value)
        {
            return new FbParameter(name, value) as IDbDataParameter;
        }

        protected override IDbConnection OpenConnectionInternal()
        {
            FbConnectionStringBuilder sb = new FbConnectionStringBuilder();
            sb.DataSource = Config.Server;
            sb.Port = Config.Port;
            sb.UserID = Config.User;
            sb.Password = Config.Password;
            sb.Database = Config.Database;

            try
            {
                FbConnection conn = new FbConnection(sb.ConnectionString);
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
