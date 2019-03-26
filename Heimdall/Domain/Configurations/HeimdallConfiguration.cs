using Heimdall.Security;
using Heimdall.Security.Contracts;

namespace Heimdall.Domain.Configurations
{
    public class HeimdallConfiguration
    {

        private static HeimdallConfiguration instance;
        public static HeimdallConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HeimdallConfiguration();
                    instance.EncryptService = new DefaultEncryptor();
                }

                return instance;
            }
        }

        private HeimdallConfiguration()
        {
            Database = new DatabaseConnectionConfig();
        }

        public DatabaseConnectionConfig Database { get; private set; }
        public IHeimdallCryptor EncryptService { get; private set; }


        public void UseMyCustomEncryptor(IHeimdallCryptor heimdallCryptor)
        {
            EncryptService = heimdallCryptor;
        }
    }
}
