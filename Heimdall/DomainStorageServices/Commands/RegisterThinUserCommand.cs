using Heimdall.Assets;
using Heimdall.Domain.Contracts;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Commands
{
    internal class RegisterThinUserCommand : IStorageCommand
    {
        private readonly User user;

        public RegisterThinUserCommand(User user)
        {
            this.user = user;
        }

        public void Execute(StorageServiceBase storageService)
        {
            string sql = SQLResources.RegisterThinUserSQL;

            int seed = DateTime.Now.Year + DateTime.Now.Day + DateTime.Now.Second * DateTime.Now.Millisecond;
            int id = new Random(seed).Next(10000);
            user.Id = $"@{id}";

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
