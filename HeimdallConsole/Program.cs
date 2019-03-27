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

            try
            {
                var user = new ThinUser("marcos8154", "81547686$Marcos", "1");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
            }

            Console.ReadKey();

        }
    }

    public class MeuEncryptor : IHeimdallCryptor
    {
        public string Decript(string text)
        {
            return "Custom Decript";
        }

        public string Encrypt(string text)
        {
            return "Custom Cript";
        }
    }
}
