using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;
using System.Collections.Generic;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class SearchOrganizationCommand : IQueryCommand<List<Organization>>
    {
        private readonly string name;

        public SearchOrganizationCommand(string name)
        {
            this.name = name;
        }

        public List<Organization> Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.SearchOrganizationSQL;
            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@name", $"%{name}%");
            var dr = storageService.ConnectionFactory.ExecuteReader();

            List<Organization> result = new List<Organization>();
            while (dr.Read())
            {
                result.Add(new Organization(
                    id: dr.GetString(0),
                    name: dr.GetString(1),
                    phone: dr.GetString(2),
                    address: dr.GetString(3)));
            }

            dr.Close();
            storageService.ConnectionFactory.CloseConnection();

            return result;
        }
    }
}
