using Heimdall.Domain;
using Heimdall.DomainStorageServices;
using Heimdall.DomainStorageServices.Contracts;
using Heimdall.Services.Contracts;
using System.Collections.Generic;

namespace Heimdall.Services
{
    internal class OrganizationService : IOrganizationService
    {
        private IOrganizationStorageService storageService;

        public OrganizationService()
        {
            storageService = new OrganizationStorageService();
        }

        public void Register(Organization organization)
        {
            storageService.Register(organization);
        }

        public Organization GetById(string id)
        {
            return storageService.GetById(id);
        }

        public void Change(Organization organization)
        {
            storageService.Change(organization);
        }

        public void Remove(Organization organization)
        {
            storageService.Remove(organization);
        }

        public List<Organization> Search(string name)
        {
            return storageService.Search(name);
        }
    }
}
