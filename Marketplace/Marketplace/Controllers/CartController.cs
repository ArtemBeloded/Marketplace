using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Marketplace.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper, IUserService userService, IOrderService orderService)
        {
            _cartService = cartService;
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
        }

        public ActionResult CartShow()
        {
            var cart = _mapper.Map<IEnumerable<CartLineVM>>(_cartService.GetCart());
            
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddItem(ShowProductVM viewModel) 
        {
            var product = _mapper.Map<Product>(viewModel);
            _cartService.AddItem(product, 1);
            
            return RedirectToAction("ListOfProduct", "Product");
        }

        public ActionResult RemoveItem(int id) 
        {
            _cartService.RemoveItem(id);
            
            return RedirectToAction("CartShow", "Cart");
        }

        public ActionResult Purchase() 
        {
            var orders = CreateListOfOrders();
            _orderService.AddOrder(orders);
            _cartService.Clear();
            
            return RedirectToAction("ListOfProduct", "Product");
        }

        public IEnumerable<Order> CreateListOfOrders() 
        {
            List<Order> orders = new List<Order>();
            var cart = _cartService.GetCart();
            var currentUser = _userService.GetUser(HttpContext.User.Identity.Name);
            foreach (var item in cart)
            {
                var order = new Order()
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UserId = currentUser.Id
                };
                orders.Add(order);
            }
            
            return orders;
        }
    }
}