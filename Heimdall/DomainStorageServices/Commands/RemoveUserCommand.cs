using Heimdall.Assets;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class RemoveUserCommand : IStorageCommand
    {
        private readonly User user;

        public RemoveUserCommand(User user)
        {
            this.user = user;
        }
        
        public void Execute(StorageServiceBase ss)
        {
            string sql = SQLResources.RemoveUserSQL;

            ss.ConnectionFactory.OpenConnection();
            ss.ConnectionFactory.CreateCommand(sql);
            ss.ConnectionFactory.AddParameter("@id", user.Id);
            ss.ConnectionFactory.ExecuteCommand();
            ss.ConnectionFactory.CloseConnection();
        }
    }
}
