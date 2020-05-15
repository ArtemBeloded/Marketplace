using Marketplace.DAL.Models;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class BuyerUserProfileVM
    {
        public User User { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}