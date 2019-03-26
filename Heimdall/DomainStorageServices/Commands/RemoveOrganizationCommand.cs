using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class RemoveOrganizationCommand : IStorageCommand
    {
        private readonly Organization organization;

        public RemoveOrganizationCommand(Organization organization)
        {
            this.organization = organization;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = "delete from Organization where Id = @id";
            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@id", organization.Id);
            storageService.ConnectionFactory.ExecuteCommand();
            storageService.ConnectionFactory.CloseConnection();
        }
    }
}
