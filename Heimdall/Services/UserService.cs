using System.Collections.Generic;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Contracts;
using Heimdall.Domain.Enum;
using Heimdall.Domain.Exceptions;
using Heimdall.DomainStorageServices;
using Heimdall.DomainStorageServices.Contracts;
using Heimdall.Services.Contracts;

namespace Heimdall.Services
{
    public class UserService : IUserService
    {
        IUserStorageService storageService;
        public UserService()
        {
            if (HeimdallConfiguration.Instance.UserTemplate == UserModelTemplate.FatUser)
                storageService = new FatUserStorageService();
            else if (HeimdallConfiguration.Instance.UserTemplate == UserModelTemplate.ThinUser)
                storageService = new ThinUserStorageService();
            else
                throw new ServiceException("User Model Template not is not defined in HeimdallConfiguration class");
        }

        public User GetByName(string userName)
        {
            return storageService.GetByName(userName);
        }

        public User GetByEmail(string userEmail)
        {
            return storageService.GetByEmail(userEmail);
        }

        public void Register(User user)
        {
            storageService.Register(user);
        }

        public void Change(User user)
        {
            storageService.Change(user);
        }

        public void Remove(User user)
        {
            storageService.Remove(user);
        }

        public List<User> Search(string searchQuery)
        {
            return storageService.Search(searchQuery);
        }
    }
}
