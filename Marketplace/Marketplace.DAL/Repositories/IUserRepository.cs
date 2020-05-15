using Marketplace.DAL.Models;
using PagedList;
using System.Threading.Tasks;

namespace Marketplace.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);

        Credential GetCredential(string username);

        IPagedList<User> GetUsers(int page, int itemsPerPage);

        void RemoveUser(string username);

        void SaveData(User user, Credential credential);
    }
}
