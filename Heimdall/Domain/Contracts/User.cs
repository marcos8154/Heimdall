using Heimdall.Domain.Configurations;
using Heimdall.Domain.Exceptions;
using Heimdall.Domain.Validation;
using System;

namespace Heimdall.Domain.Contracts
{
    public abstract class User
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string OrganizationId { get; private set; }
        public Organization Organization { get; internal set; }
        public virtual string Email
        {
            get
            {
                throw new DomainException("This user template does not support this feature");
            }
            internal set
            {
                throw new DomainException("This user template does not support this feature");
            }
        }
        public virtual string PhoneNumber
        {
            get
            {
                throw new DomainException("This user template does not support this feature");
            }
            internal set
            {
                throw new DomainException("This user template does not support this feature");
            }
        }
        public virtual string Address
        {
            get
            {
                throw new DomainException("This user template does not support this feature");
            }
            internal set
            {
                throw new DomainException("This user template does not support this feature");
            }
        }

        public virtual void SetEmail(string email)
        {
            throw new DomainException("This user template does not support this feature");
        }

        public virtual void SetPhoneNumber(string phoneNumber)
        {
            throw new DomainException("This user template does not support this feature");
        }

        public virtual void SetAddress(string address)
        {
            throw new DomainException("This user template does not support this feature");
        }

        public void SetUserName(string name)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(name, "User name can not be empty");
            Name = name;
        }

        public void SetPassword(string password)
        {
            HeimdallConfiguration.Instance.PasswordSecurityValidator.ValidPasswordSecurity(password);
            Password = HeimdallConfiguration.Instance.EncryptService.Decript(password);
        }

        public string RevealPassword()
        {
            return HeimdallConfiguration.Instance.EncryptService.Decript(Password);
        }

        public void SetOrganizationId(string organizationId)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(organizationId, "Invalid OrganizationId");
            OrganizationId = organizationId;
        }
    }
}
