using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class ChangeOrganizationCommand : IStorageCommand
    {
        private Organization organization;
        public ChangeOrganizationCommand(Organization organization)
        {
            this.organization = organization;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.ChangeOrganizationSQL;

            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@id", organization.Id);
            storageService.ConnectionFactory.AddParameter("@name", organization.Name);
            storageService.ConnectionFactory.AddParameter("@phone", organization.Phone);
            storageService.ConnectionFactory.AddParameter("@address", organization.Address);
            storageService.ConnectionFactory.ExecuteCommand();
            storageService.ConnectionFactory.CloseConnection();
        }
    }
}
