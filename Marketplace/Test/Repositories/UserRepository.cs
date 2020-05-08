﻿using Marketplace.DAL.DataBaseContext;
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
        private MarketplaceContext _marketplaceContext;

        public UserRepository(MarketplaceContext marketplaceContext)
        {
            _marketplaceContext = marketplaceContext;
        }

        public User GetUser(string username) 
        {
            using (_marketplaceContext) 
            {
                var user = _marketplaceContext.Users.FirstOrDefault(x => x.Username == username);
                return user;
            }
        }

        public Credential GetCredential(string username) 
        {
            using (_marketplaceContext) 
            {
                var credential = _marketplaceContext.Credentials.FirstOrDefault(x => x.Username == username);
                return credential;
            }
        }

        public List<User> GetUsers() 
        {
            using (_marketplaceContext) 
            {
                return _marketplaceContext.Users.ToList();
            }    
        }

        public void RemoveUser(string username) 
        {
            using (_marketplaceContext) 
            {
                var user = _marketplaceContext.Users.FirstOrDefault(x => x.Username == username);
                _marketplaceContext.Users.Remove(user);
                _marketplaceContext.SaveChanges();
            }
        } 

        public void SaveData(User user, Credential credential) 
        {
            using (_marketplaceContext) 
            {
                _marketplaceContext.Users.Add(user);
                _marketplaceContext.Credentials.Add(credential);
                _marketplaceContext.SaveChanges();
            }
        }
    }
}
