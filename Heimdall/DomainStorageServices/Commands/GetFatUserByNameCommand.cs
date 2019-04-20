using Heimdall.Assets;
using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System.Data;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class GetFatUserByNameCommand : IQueryCommand<User>
    {
        private readonly string name;

        public GetFatUserByNameCommand(string name)
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

            user = new FatUser(
                    dr.GetString(0), //Id
                    dr.GetString(1), //Name
                    HeimdallConfiguration.Instance.EncryptService.Decrypt(dr.GetString(2)), //Password
                    dr.GetString(3), //OrganizationId
                    dr.GetString(4), //Email
                    dr.GetString(5), //PhoneNumber
                    dr.GetString(6)); //Address

            dr.Close();
            ss.ConnectionFactory.CloseConnection();
            return user;
        }
    }
}
