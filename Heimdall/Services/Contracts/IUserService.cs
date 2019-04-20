using Heimdall.Domain.Contracts;
using Heimdall.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdall.Services.Contracts
{
    public interface IUserService
    {
        User GetByName(string userName);

        User GetByEmail(string userEmail);

        void Register(User user);

        void Change(User user);

        void Remove(User user);

        List<User> Search(string searchQuery);
    }
}
