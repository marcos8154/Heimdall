using Heimdall.Domain;
using Heimdall.Domain.Exceptions;
using Heimdall.DomainStorageServices;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Services
{
    public class OrganizationService
    {
        private IOrganizationStorageService storageService;

        public OrganizationService()
        {
            storageService = new OrganizationStorageService();
        }

        public void Register(Organization organization)
        {
            try
            {
                storageService.Register(organization);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public Organization FindById(string id)
        {
            try
            {
                return storageService.GetById(id);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public void Change(Organization organization)
        {
            try
            {
                storageService.Change(organization);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public void Remove(Organization organization)
        {
            try
            {
                storageService.Remove(organization);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public List<Organization> Search(string name)
        {
            try
            {
                return storageService.Search(name);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }
    }
}
