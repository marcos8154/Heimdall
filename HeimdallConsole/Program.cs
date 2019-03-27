using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Security;
using Heimdall.Security.Contracts;
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
                var user = new FatUser("marcos8154", "81547686$Marcos", "1", "marcos8154@gmail.com", "222", "222");
              //  user.SetEmail("marcos8154@gmail.com");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
            }

            Console.ReadKey();

        }
    }
}
