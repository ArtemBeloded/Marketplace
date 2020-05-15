using Marketplace.DAL.Models;
using Marketplace.DAL.Repositories;
using System.Collections.Generic;

namespace Marketplace.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(IEnumerable<Order> orders)
        {
            _orderRepository.AddOrder(orders);
        }

        public IEnumerable<Order> GetOrders(int userId)
        {
           return _orderRepository.GetOrders(userId);
        }
    }
}
