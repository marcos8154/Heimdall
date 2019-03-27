using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain.Contracts
{
    public interface IUserPasswordSecurityValidator
    {
        void ValidPasswordSecurity(string password);
    }
}
