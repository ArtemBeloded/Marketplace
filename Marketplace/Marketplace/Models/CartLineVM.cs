using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class CartLineVM
    {
        public ProductCartLineVM Product { get; set; }

        public int Quantity { get; set; }
    }
}