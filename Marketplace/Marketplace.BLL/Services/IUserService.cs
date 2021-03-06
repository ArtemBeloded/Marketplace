﻿using Marketplace.DAL.Models;
using PagedList;

namespace Marketplace.BLL.Services
{
    public interface IUserService
    {
        User GetUser(string username);

        Credential GetCredential(string username);

        IPagedList<User> GetUsers(int page, int itemsPerPage);

        void RemoveUser(string username);

        void SaveData(User user, Credential credential);
    }
}
