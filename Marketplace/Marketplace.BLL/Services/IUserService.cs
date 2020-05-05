using Marketplace.DAL.Models;
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
        Credential GetCredential(string username);
        List<User> GetUsers();
        void RemoveUser(string username);
        void SaveData(User user, Credential credential);
    }
}
