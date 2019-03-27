using Heimdall.Domain.Contracts;
using Heimdall.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Security
{
    internal class LowLevelPasswordSecurityValidator : IUserPasswordSecurityValidator
    {
        public void ValidPasswordSecurity(string password)
        {
            if (string.IsNullOrEmpty(password) ||
              string.IsNullOrWhiteSpace(password))
                throw new WeakPasswordException("Weak password. Password must contain between 1 and 10 characters");
            if (password.Length < 1 ||
                password.Length > 10)
                throw new WeakPasswordException("Weak password. Password must contain between 1 and 10 characters");
        }
    }
}
