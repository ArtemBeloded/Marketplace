using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Services
{
    public interface IOrderService
    {
        void AddOrder(IEnumerable<Order> orders);

        IEnumerable<Order> GetOrders(int userId);
    }
}
