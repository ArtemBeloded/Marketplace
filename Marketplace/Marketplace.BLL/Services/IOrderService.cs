using Marketplace.DAL.Models;
using System.Collections.Generic;

namespace Marketplace.BLL.Services
{
    public interface IOrderService
    {
        void AddOrder(IEnumerable<Order> orders);

        IEnumerable<Order> GetOrders(int userId);
    }
}
