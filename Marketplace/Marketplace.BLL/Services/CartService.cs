using Marketplace.DAL.Models;
using Marketplace.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepositiry;

        public CartService(ICartRepository cartRepositiry)
        {
            _cartRepositiry = cartRepositiry;
        }

        public void AddItem(Product product, int quantity) 
        {
            _cartRepositiry.AddItem(product, quantity);
        }

        public void RemoveItem(Guid id) 
        {
            _cartRepositiry.RemoveItem(id);
        }

        public double CountTotalValue() 
        {
            return _cartRepositiry.CountTotalValue();
        }

        public void Clear() 
        {
            _cartRepositiry.Clear();
        }

        public IEnumerable<CartLine> GetCart() 
        {
            return _cartRepositiry.GetCart();
        }
    }
}
