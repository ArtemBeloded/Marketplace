using Marketplace.DAL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Services
{
    public interface IUserService
    {
        User GetUser(string username);
        Task<User> GetUser(string username, string password);
        Credential GetCredential(string username);
        IPagedList<User> GetUsers(int page, int itemsPerPage);
        void RemoveUser(string username);
        void SaveData(User user, Credential credential);
    }
}
