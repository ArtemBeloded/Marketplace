using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.DAL.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(IEnumerable<Order> orders);

        IEnumerable<Order> GetOrders(int userId);
    }
}
