using Heimdall.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.DomainStorageServices.Contracts
{
    internal interface IOrganizationStorageService
    {
        void Register(Organization organization);

        void Change(Organization organization);

        void Remove(Organization organization);

        List<Organization> Search(string name);

        Organization GetById(string id);
    }
}
