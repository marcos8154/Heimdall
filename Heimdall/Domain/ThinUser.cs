using System;
using System.Collections.Generic;
using System.Text;
using Heimdall.Domain.Contracts;

namespace Heimdall.Domain
{
    public class ThinUser : User
    {
        internal ThinUser(string id, string name, string password, string organizationId)
        {
            Id = id;
            ResolveValues(name, password, organizationId);
        }

        public ThinUser(string name, string password, string organizationId)
        {
            ResolveValues(name, password, organizationId);
        }

        private void ResolveValues(string name, string password, string organizationId)
        {
            SetUserName(name);
            SetPassword(password);
            SetOrganizationId(organizationId);
        }
    }
}
