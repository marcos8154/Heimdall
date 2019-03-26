using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class GetOrganizationByIdCommand : IQueryCommand<Organization>
    {
        private readonly string organizationId;

        public GetOrganizationByIdCommand(string organizationId)
        {
            this.organizationId = organizationId;
        }

        public Organization Execute(StorageServiceBase storageService)
        {
            string sql = "select * from Organization where Id = @id";
            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@id", organizationId);
            var dr = storageService.ConnectionFactory.ExecuteReader();

            Organization result = null;

            if (dr.Read())
            {
                result = new Organization(
                    id: dr.GetString(0),
                    name: dr.GetString(1),
                    phone: dr.GetString(2),
                    address: dr.GetString(3));
            }

            dr.Close();
            storageService.ConnectionFactory.CloseConnection();

            return result;
        }
    }
}
