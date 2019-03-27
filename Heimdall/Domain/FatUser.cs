using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain
{
    public class FatUser : UserTemplate
    {
        public override string Email { get; internal set; }
        public override string Address { get; internal set; }
        public override string PhoneNumber { get; internal set; }

        public override void SetEmail(string email)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            AssertionConcern.AssertArgumentNotNullOrEmpty(email, "Email can not be empty");
            AssertionConcern.AssertArgumentMatches(pattern , email, "Invalid email");
            Email = email;
        }

        public override void SetAddress(string address)
        {
            AssertionConcern.AssertArgumentNotEmpty(address, "User address can not be empty");
            Address = address;
        }
        
        public override void SetPhoneNumber(string phoneNumber)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(phoneNumber, "User phonenumber can not be empty");
            PhoneNumber = phoneNumber;
        }
    }
}
