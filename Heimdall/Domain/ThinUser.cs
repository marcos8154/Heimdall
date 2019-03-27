using Heimdall.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Domain
{
    public class ThinUser : User
    {
        public ThinUser(string name, string password, string organizationId)
        {
            SetUserName(name);
            SetPassword(password);
            SetOrganizationId(organizationId);
        }
    }
}
