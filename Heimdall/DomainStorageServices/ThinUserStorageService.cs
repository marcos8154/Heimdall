using Heimdall.Domain.Contracts;
using Heimdall.Domain.Enum;
using Heimdall.Domain.Exceptions;
using Heimdall.DomainStorageServices.Commands;
using Heimdall.DomainStorageServices.Contracts;
using System;
using System.Collections.Generic;

namespace Heimdall.DomainStorageServices
{
    internal class ThinUserStorageService : StorageServiceBase, IUserStorageService
    {
        public ThinUserStorageService()
            : base("HUser")
        {

        }

        public UserModelTemplate Template
        {
            get
            {
                return UserModelTemplate.ThinUser;
            }
        }

        public void Change(User user)
        {
            try
            {
                IStorageCommand command = new ChangeThinUserCommand(user);
                command.Execute(this);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public User GetByEmail(string userEmail)
        {
            throw new ServiceException("This user template dont support this feature");
        }

        public User GetByName(string userName)
        {
            try
            {
                IQueryCommand<User> command = new GetThinUserByNameCommand(userName);
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
                IStorageCommand command = new RegisterThinUserCommand(user);
                command.Execute(this);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public List<User> Search(string searchQuery)
        {
            try
            {
                IQueryCommand<List<User>> command = new SearchThinUserCommand(searchQuery);
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
create table HUser
(
    Id varchar(50) not null,
    Name varchar(50) not null,
    Password varchar(300) not null,
    OrganizationId varchar(40) not null,

    primary key(Id)
)";
        }
    }
}
