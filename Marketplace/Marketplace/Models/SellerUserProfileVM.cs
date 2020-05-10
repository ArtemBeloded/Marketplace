using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class SellerUserProfileVM
    {
        public User User { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}