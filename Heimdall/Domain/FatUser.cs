using Heimdall.Domain.Contracts;
using Heimdall.Domain.Exceptions;
using Heimdall.Domain.Validation;
using System;

namespace Heimdall.Domain
{
    public class FatUser : User
    {
        public override string Email { get; internal set; }
        public override string Address { get; internal set; }
        public override string PhoneNumber { get; internal set; }

        public override void SetEmail(string email)
        {
            try
            {
                string pattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
                AssertionConcern.AssertArgumentNotNullOrEmpty(email, "Email can not be empty");
                AssertionConcern.AssertArgumentMatches(pattern, email, "Invalid email");
                Email = email;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        public override void SetAddress(string address)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEmpty(address, "User address can not be empty");
                Address = address;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        public override void SetPhoneNumber(string phoneNumber)
        {
            try
            {
                AssertionConcern.AssertArgumentNotNullOrEmpty(phoneNumber, "User phonenumber can not be empty");
                PhoneNumber = phoneNumber;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        internal FatUser(string id, string name, string password, string organizationId,
            string email, string address, string phoneNumner)
        {
            Id = id;
            ResolveValues(name, password, organizationId, email, address, phoneNumner);
        }

        public FatUser(string name, string password, string organizationId,
            string email, string address, string phoneNumner)
        {
            ResolveValues(name, password, organizationId, email, address, phoneNumner);
        }

        private void ResolveValues(string name, string password, string organizationId,
            string email, string address, string phoneNumner)
        {
            SetUserName(name);
            SetPassword(password);
            SetOrganizationId(organizationId);
            SetEmail(email);
            SetAddress(address);
            SetPhoneNumber(phoneNumner);
        }
    }
}
