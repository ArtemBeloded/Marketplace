using Marketplace.DAL.DataBaseContext;
using Marketplace.DAL.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Linq;

namespace Marketplace.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MarketplaceContext _marketplaceContext;

        public UserRepository(MarketplaceContext marketplaceContext)
        {
            _marketplaceContext = marketplaceContext;
        }

        public User GetUser(string username)
        {
            var user = _marketplaceContext.Users.Include(u => u.Role).FirstOrDefault(x => x.Username == username);
            
            return user;
        }

        public Credential GetCredential(string username)
        {
            var credential = _marketplaceContext.Credentials.FirstOrDefault(x => x.Username == username);
            
            return credential;
        }

        public IPagedList<User> GetUsers(int page, int itemsPerPage)
        {
            var users = _marketplaceContext.Users.AsQueryable();
            users = users.Include(u => u.Role).Where(x => x.Role.Name == "Seller" | x.Role.Name == "Buyer");
            
            return users.ToList().ToPagedList(page, itemsPerPage);
        }

        public void RemoveUser(string username)
        {

            var user = _marketplaceContext.Users.FirstOrDefault(x => x.Username == username);
            _marketplaceContext.Users.Remove(user);
           
            _marketplaceContext.SaveChanges();
        }

        public void SaveData(User user, Credential credential)
        {
            _marketplaceContext.Users.Add(user);
            _marketplaceContext.Credentials.Add(credential);
           
            _marketplaceContext.SaveChanges();
        }
    }
}
