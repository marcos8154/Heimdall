using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System.Data;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class GetThinUserByNameCommand : IQueryCommand<User>
    {
        private readonly string name;

        public GetThinUserByNameCommand(string name)
        {
            this.name = name;
        }

        public User Execute(StorageServiceBase ss)
        {
            string sql = SQLResources.GetUserByNameSQL;

            ss.ConnectionFactory.OpenConnection();
            ss.ConnectionFactory.CreateCommand(sql);
            ss.ConnectionFactory.AddParameter("@name", name);
            IDataReader dr = ss.ConnectionFactory.ExecuteReader();

            User user = null;
            dr.Read();

            user = new ThinUser(
                    dr.GetString(0), //Id
                    dr.GetString(1), //Name
                    HeimdallConfiguration.Instance.EncryptService.Decrypt(dr.GetString(2)), //Password
                    dr.GetString(3) //OrganizationId
                );

            dr.Close();
            ss.ConnectionFactory.CloseConnection();
            return user;
        }
    }
}
