using Marketplace.DAL.DataBaseContext;
using Marketplace.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private MarketplaceContext _marketplaceContext;
        public OrderRepository(MarketplaceContext marketplaceContext)
        {
            _marketplaceContext = marketplaceContext;
        }

        public void AddOrder(IEnumerable<Order> orders)
        {
            _marketplaceContext.Orders.AddRange(orders);
            _marketplaceContext.SaveChanges();
        }

        public IEnumerable<Order> GetOrders(int userId)
        {
            var orders = _marketplaceContext.Orders.AsQueryable();
            orders = _marketplaceContext.Orders.Where(x => x.UserId == userId);
            return orders.ToList();
        }

    }
}
