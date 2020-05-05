using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marketplace.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> listOfUsers;
        private List<Credential> listOfCredential;
        private readonly HttpContextBase _httpContext;

        public UserRepository(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
            InitUser();
            InitCredential();
        }

        public User GetUser(string username) 
        {
            var user = listOfUsers.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public Credential GetCredential(string username) 
        {
            var credential = listOfCredential.FirstOrDefault(x => x.Username == username);
            return credential;
        }

        public List<User> GetUsers() 
        {
            return listOfUsers;
        }

        public void RemoveUser(string username) 
        {
            var user = listOfUsers.FirstOrDefault(x => x.Username == username);
            listOfUsers.Remove(user);
        } 

        public void SaveData(User user, Credential credential) 
        {
            listOfUsers.Add(user);
            listOfCredential.Add(credential);
        }

        private void InitUser()
        {
            listOfUsers = _httpContext.Session["Users"] as List<User>;
            if (listOfUsers == null)
            {
                _httpContext.Session["Users"] = new List<User>();
                listOfUsers = _httpContext.Session["Users"] as List<User>;
            }
        }

        private void InitCredential()
        {
            listOfCredential = _httpContext.Session["Credential"] as List<Credential>;
            if (listOfCredential == null)
            {
                _httpContext.Session["Credential"] = new List<Credential>();
                listOfCredential = _httpContext.Session["Credential"] as List<Credential>;
            }
        }
    }
}
