using System;
using Heimdall.Domain.Contracts;
using Heimdall.Security;
using Heimdall.Security.Enum;
using Heimdall.Security.Contracts;
using Heimdall.Domain.Enum;

namespace Heimdall.Domain.Configurations
{
    public class HeimdallConfiguration
    {
        #region strange paraphernalia you will not want to know what it is :)
        private static HeimdallConfiguration instance;
        public static HeimdallConfiguration Instance
        {
            get
            {
                if (instance == null)
                    instance = new HeimdallConfiguration();
            
                return instance;
            }
        }

        private HeimdallConfiguration()
        {
            Database = new DatabaseConnectionConfig();
            EncryptService = new DefaultEncryptor();
            SetPasswordSecurityLevel(UserPasswordSecurityLevel.MEDIUM, null);
            SetUserTemplate(UserModelTemplate.ThinUser);
        }

        private IUserPasswordSecurityValidator GetInstancePasswdValidator(UserPasswordSecurityLevel level,
         IUserPasswordSecurityValidator myCustomPasswordSecurityValidatior = null)
        {
            switch (level)
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
        #endregion

        public DatabaseConnectionConfig Database { get; private set; }

        public IHeimdallCryptor EncryptService { get; private set; }

        public UserModelTemplate UserTemplate { get; private set; }

        public IUserPasswordSecurityValidator PasswordSecurityValidator { get; private set; }
        
        public void SetPasswordSecurityLevel(UserPasswordSecurityLevel passwordSecurityLevel,
            IUserPasswordSecurityValidator myCustomPasswordSecurityValidatior = null)
        {
            PasswordSecurityValidator = GetInstancePasswdValidator(passwordSecurityLevel,
                myCustomPasswordSecurityValidatior);
        }
        
        public void UseMyCustomEncryptor(IHeimdallCryptor heimdallCryptor)
        {
            EncryptService = heimdallCryptor;
        }
        
        public void SetUserTemplate(UserModelTemplate template)
        {
            UserTemplate = template;
        }
    }
}
