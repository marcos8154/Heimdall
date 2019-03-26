using Heimdall.Domain.Configurations;
using Heimdall.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Heimdall.Contract
{
    internal abstract class ConnectionFactoryBase
    {
        private IDbCommand DbCommand { get; set; }
        private IDbTransaction DbTransaction { get; set; }
        private IDbConnection DbConnection { get; set; }

        protected DatabaseConnectionConfig Config { get; private set; }
        protected abstract IDbConnection OpenConnectionInternal();
        protected abstract IDbTransaction BeginTransactionInternal(IDbConnection connection, IsolationLevel isolationLevel);
        protected abstract IDbCommand CreateCommandInternal(string commandText, IDbConnection connection, IDbTransaction transaction);
        protected abstract IDbDataParameter GetParameterInternal(string name, object value);

        public override string ToString()
        {
            return $"Configured as {Config.GetDbVendor()} on server '{Config.Server}' and database '{Config.Database}'";
        }

        internal void CreateCommand(string commandText)
        {
            DbCommand = CreateCommandInternal(commandText, DbConnection, DbTransaction);
        }

        internal void AddParameter(string name, object value)
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbCommand not initialized. Call 'CreateCommand' method before adding parameters");
            DbCommand.Parameters.Add(GetParameterInternal(name, value));
        }

        internal void ExecuteCommand()
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbCommand not initialized. Call 'CreateCommand' method before adding parameters");
            DbCommand.ExecuteNonQuery();
        }

        internal void BeginTransaction(IsolationLevel isolationLevel)
        {
            DbTransaction = BeginTransactionInternal(DbConnection, isolationLevel);
        }
    
        internal void OpenConnection()
        {
            DbConnection = OpenConnectionInternal();
        }

        internal void CloseConnection()
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbConnection not initialized. Call 'OpenConnection' method before close then");
            DbConnection.Close();
        }

        internal void CommitTransaction()
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbTransaction not initialized. Call 'BeginTransaction' method before commit then");
            DbTransaction.Commit();
        }

        internal void RollBackTransaction()
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbTransaction not initialized. Call 'BeginTrancation' method before rollback then");
            DbTransaction.Rollback();
        }

        internal IDataReader ExecuteReader()
        {
            if (DbCommand == null)
                throw new ConnectionFactoryException("DbCommand not initialized. Call 'CreateCommand' method before execute reader");
            return DbCommand.ExecuteReader();
        }

        public ConnectionFactoryBase()
        {
            this.Config = HeimdallConfiguration.Instance.Database;
        }
    }
}
