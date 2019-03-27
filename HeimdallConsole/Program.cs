using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.Security;
using System;

namespace HeimdallConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HeimdallConfiguration.Instance.Database.UseSQLServer("localhost", "sa", "81547686", "AbcInfo");
            HeimdallConfiguration.Instance.SetPasswordSecurityLevel(UserPasswordSecurityLevel.MEDIUM);
            HeimdallConfiguration.Instance.EncryptService.SetPassword("MySecurePa$$word@123456.C#");

            try
            {
                var user = new FatUser("marcos8154", "2445652356$MyLife", "1", "user.x@gmail.com", "222", "222");
                TestUser(user);
                //  user.SetEmail("marcos8154@gmail.com");
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
