using Heimdall.Domain;
using Heimdall.Domain.Exceptions;
using Heimdall.DomainStorageServices.Commands;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;

namespace Heimdall.DomainStorageServices
{
    internal class OrganizationStorageService : StorageServiceBase, IOrganizationStorageService
    {
        public OrganizationStorageService()
        {
            SetTableName("Organization");
        }

        public void Change(Organization organization)
        {
            try
            {
                IStorageCommand command = new ChangeOrganizationCommand(organization);
                command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public Organization GetById(string id)
        {
            try
            {
                IQueryCommand<Organization> command = new GetOrganizationByIdCommand(id);
                return command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public void Register(Organization organization)
        {
            try
            {
                IStorageCommand command = new RegisterOrganizationCommand(organization);
                command.Execute(this);
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
                IStorageCommand command = new RemoveOrganizationCommand(organization);
                command.Execute(this);
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
                IQueryCommand<List<Organization>> command = new SearchOrganizationCommand(name);
                return command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        protected internal override string GetTableCreationScript()
        {
            return @"
create table Organization
(
    Id varchar (10) not null,
    Name varchar(50) not null,
    Phone varchar(15) not null,
    Address varchar(100) not null,

    primary key(Id)
)
";
        }
    }
}
