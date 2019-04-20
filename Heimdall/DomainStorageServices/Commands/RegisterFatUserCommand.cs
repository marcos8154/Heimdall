using Heimdall.Assets;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class RegisterFatUserCommand : IStorageCommand
    {
        private readonly User user;

        public RegisterFatUserCommand(User user)
        {
            this.user = user;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.RegisterFatUserSQL;

            int seed = DateTime.Now.Year + DateTime.Now.Day + DateTime.Now.Second * DateTime.Now.Millisecond;
            int id = new Random(seed).Next(10000);
            user.Id = $"@{id}";

            storageService.ConnectionFactory.OpenConnection();
            storageService.ConnectionFactory.CreateCommand(sql);
            storageService.ConnectionFactory.AddParameter("@id", user.Id);
            storageService.ConnectionFactory.AddParameter("@name", user.Name);
            storageService.ConnectionFactory.AddParameter("@password", user.Password);
            storageService.ConnectionFactory.AddParameter("@email", user.Email);
            storageService.ConnectionFactory.AddParameter("@organizationId", user.OrganizationId);
            storageService.ConnectionFactory.AddParameter("@phoneNumber", user.PhoneNumber);
            storageService.ConnectionFactory.AddParameter("@address", user.Address);
            storageService.ConnectionFactory.ExecuteCommand();
            storageService.ConnectionFactory.CloseConnection();
        }
    }
}
