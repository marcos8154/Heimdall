using Heimdall.Domain.Configurations;
using Heimdall.Security.Contracts;
using Heimdall.Services;
using Heimdall.Services.Contracts;
using System;

namespace HeimdallConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HeimdallConfiguration.Instance.Database.UseSQLServer("localhost", "sa", "81547686", "AbcInfo");
            HeimdallConfiguration.Instance.UseMyCustomEncryptor(new MeuEncryptor());
            string crypto = HeimdallConfiguration.Instance.EncryptService.Encrypt("Meu nome");
            string decrypto = HeimdallConfiguration.Instance.EncryptService.Decript("Meu nome");

            Console.WriteLine(crypto);
            Console.WriteLine(decrypto);

            IOrganizationService service = ServiceResolver<IOrganizationService>.Resolve();

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
