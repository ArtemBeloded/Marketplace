using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class BuyerUserProfileVM
    {
        public User User { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}