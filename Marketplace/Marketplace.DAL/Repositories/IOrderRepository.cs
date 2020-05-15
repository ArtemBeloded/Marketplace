using Marketplace.DAL.Models;
using System.Collections.Generic;

namespace Marketplace.DAL.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(IEnumerable<Order> orders);

        IEnumerable<Order> GetOrders(int userId);
    }
}
