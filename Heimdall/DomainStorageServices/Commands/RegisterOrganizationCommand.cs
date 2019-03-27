using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class RegisterOrganizationCommand : IStorageCommand
    {
        private readonly Organization organization;

        public RegisterOrganizationCommand(Organization organization)
        {
            this.organization = organization;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.RegisterOrganizationSQL;

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
