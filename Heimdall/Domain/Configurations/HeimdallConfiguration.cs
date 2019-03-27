using Heimdall.Domain.Contracts;
using Heimdall.Domain.Validation;
using Heimdall.Security;
using Heimdall.Security.Contracts;
using System;

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
                    instance.SetPasswordSecurityLevel(UserPasswordSecurityLevel.MEDIUM, null);
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

        public IUserPasswordSecurityValidator PasswordSecurityValidator { get; private set; }

        public void SetPasswordSecurityLevel(UserPasswordSecurityLevel passwordSecurityLevel,
            IUserPasswordSecurityValidator myCustomPasswordSecurityValidatior = null)
        {
            PasswordSecurityValidator = GetInstancePasswdValidator(passwordSecurityLevel, myCustomPasswordSecurityValidatior);
        }

        private IUserPasswordSecurityValidator GetInstancePasswdValidator(UserPasswordSecurityLevel level,
           IUserPasswordSecurityValidator myCustomPasswordSecurityValidatior = null)
        {
            switch(level)
            {
                case UserPasswordSecurityLevel.LOW: return new LowLevelPasswordSecurityValidator();
                case UserPasswordSecurityLevel.MEDIUM: return new MediumLevelPasswordSecurityValidator();
                case UserPasswordSecurityLevel.HIGHT: return new HightLevelPasswordSecurityValidator();
                case UserPasswordSecurityLevel.CUSTOM:
                    if (myCustomPasswordSecurityValidatior == null)
                        throw new InvalidOperationException("Custom password validator instance can not be null");
                    return myCustomPasswordSecurityValidatior;
                default: throw new InvalidCastException("Invalid password security validator");
            }
        }

        public void UseMyCustomEncryptor(IHeimdallCryptor heimdallCryptor)
        {
            EncryptService = heimdallCryptor;
        }
    }
}
