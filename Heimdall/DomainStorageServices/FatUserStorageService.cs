using Heimdall.Domain.Contracts;
using Heimdall.Domain.Enum;
using Heimdall.Domain.Exceptions;
using Heimdall.DomainStorageServices.Commands;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;

namespace Heimdall.DomainStorageServices
{
    internal class FatUserStorageService : StorageServiceBase, IUserStorageService
    {
        public FatUserStorageService() :
            base("HUser")
        {
        }

        public UserModelTemplate Template
        {
            get
            {
                return UserModelTemplate.FatUser;
            }
        }

        public void Change(User user)
        {
            try
            {
                IStorageCommand command = new ChangeFatUserCommand(user);
                command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public User GetByEmail(string userEmail)
        {
            try
            {
                IQueryCommand<User> command = new GetFatUserByEmailCommand(userEmail);
                return command.Execute(this);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public User GetByName(string userName)
        {
            try
            {
                IQueryCommand<User> command = new GetFatUserByNameCommand(userName);
                return command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public void Register(User user)
        {
            try
            {
                IStorageCommand command = new RegisterFatUserCommand(user);
                command.Execute(this);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public void Remove(User user)
        {
            try
            {
                IStorageCommand command = new RemoveUserCommand(user);
                command.Execute(this);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public List<User> Search(string searchQuery)
        {
            try
            {
                IQueryCommand<List<User>> command = new SearchFatUserCommand(searchQuery);
                return command.Execute(this);
            }
            catch(Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        protected internal override string GetTableCreationScript()
        {
            return @"
create table HUser
(
    Id varchar(50) not null,
    Name varchar(50) not null,
    Password varchar(300) not null,
    OrganizationId varchar(40) not null,
    Email varchar(150) not null,
    PhoneNumber varchar(25) not null,
    Address varchar(500) not null

    primary key(Id)
)";
        }
    }
}
