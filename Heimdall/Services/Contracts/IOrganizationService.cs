using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Services.Contracts
{
    public interface IOrganizationService
    {
        void Register(Organization organization);

        void Change(Organization organization);

        void Remove(Organization organization);

        List<Organization> Search(string name);

        Organization FindById(string id);
    }
}
