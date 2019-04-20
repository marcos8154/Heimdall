using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System.Collections.Generic;
using System.Data;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class SearchFatUserCommand : IQueryCommand<List<User>>
    {
        private readonly string query;

        public SearchFatUserCommand(string query)
        {
            this.query = query;
        }

        public List<User> Execute(StorageServiceBase ss)
        {
            string sql = SQLResources.SearchUsersSQL;

            ss.ConnectionFactory.OpenConnection();
            ss.ConnectionFactory.CreateCommand(sql);
            ss.ConnectionFactory.AddParameter("@name", $"%{query}%");
            IDataReader dr = ss.ConnectionFactory.ExecuteReader();

            List<User> result = new List<User>();
            while (dr.Read())
            {
                result.Add(new FatUser(
                    dr.GetString(0), //Id
                    dr.GetString(1), //Name
                    HeimdallConfiguration.Instance.EncryptService.Decrypt(dr.GetString(2)), //Password
                    dr.GetString(3), //OrganizationId
                    dr.GetString(4), //Email
                    dr.GetString(5), //PhoneNumber
                    dr.GetString(6))); //Address
            }

            dr.Close();
            ss.ConnectionFactory.CloseConnection();
            return result;
        }
    }
}
