using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.Domain.Enum;
using Heimdall.Security;
using Heimdall.Security.Enum;
using Heimdall.Services;
using Heimdall.Services.Contracts;
using System;

namespace HeimdallConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HeimdallConfiguration.Instance.Database.UseSQLServer("localhost", "sa", "81547686", "Heimdall");
            HeimdallConfiguration.Instance.SetPasswordSecurityLevel(UserPasswordSecurityLevel.LOW);
            HeimdallConfiguration.Instance.EncryptService.SetPassword("MySecurePa$$word@123456.C#");
            HeimdallConfiguration.Instance.SetUserTemplate(UserModelTemplate.ThinUser);

            try
            {
                var orgService = ServiceResolver<IOrganizationService>.Resolve();
                orgService.Register(new Organization("1", "Empresa", "33565868", "Av. Rua. Bairro"));
                var service = ServiceResolver<IUserService>.Resolve();

          //      service.Register(new ThinUser("Marcos", "81547686", "1"));

                var user = service.GetByName("Marcos");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
            }

            Console.ReadKey();

        }

        private static void TestUser(User user)
        {
            string email = user.Email;
        }
    }
}
