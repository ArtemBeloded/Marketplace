using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marketplace.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private Cart _cart;
        private readonly HttpContextBase _httpContext;
        public CartRepository(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
            InitialSession();
        }

        public void AddItem(Product product, int quantity) 
        {
            CartLine item = _cart.CartList.Where(g => g.Product.Id == product.Id).FirstOrDefault();
            if (item == null)
            {
                _cart.CartList.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else 
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Guid id) 
        {
            _cart.CartList.RemoveAll(g => g.Product.Id == id);
        }

        public double CountTotalValue() 
        {
            return _cart.CartList.Sum(g => g.Product.Price * g.Quantity);
        }

        public void Clear() 
        {
            _cart.CartList.Clear();
        }

        public IEnumerable<CartLine> GetCart() 
        {
            return _cart.CartList;
        }

        private void InitialSession() 
        {
            _cart = _httpContext.Session[_httpContext.User.ToString()] as Cart;
            if (_cart == null) 
            {
                _httpContext.Session[_httpContext.User.ToString()] = new Cart();
                _cart = _httpContext.Session[_httpContext.User.ToString()] as Cart;
            }
        }
    }
}
