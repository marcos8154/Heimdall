using Heimdall.Assets;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class ChangeThinUserCommand : IStorageCommand
    {
        private readonly User user;

        public ChangeThinUserCommand(User user)
        {
            this.user = user;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.ChangeThinUserSQL;

            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@id", user.Id);
            storageService.ConnectionFactory.AddParameter("@name", user.Name);
            storageService.ConnectionFactory.AddParameter("@password", user.Password);
            storageService.ConnectionFactory.AddParameter("@organizationId", user.OrganizationId);
            storageService.ConnectionFactory.ExecuteCommand();
            storageService.ConnectionFactory.CloseConnection();
        }
    }
}
