using System.Collections.Generic;

namespace Marketplace.DAL.Models
{
    public class Cart
    {
        public List<CartLine> CartList { get; set; } = new List<CartLine>();
    }

    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
