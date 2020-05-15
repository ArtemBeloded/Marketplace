using Marketplace.DAL.Models;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class SellerUserProfileVM
    {
        public User User { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}