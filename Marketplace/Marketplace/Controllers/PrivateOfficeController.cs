using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
using Marketplace.Helpers;
using Marketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.Controllers
{
    public class PrivateOfficeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public PrivateOfficeController(IProductService productService, IMapper mapper, IUserService userService, IOrderService orderService)
        {
            _productService = productService;
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
        }

        public ActionResult UserProfile()
        {

            var user = _userService.GetUser(HttpContext.User.Identity.Name);
            if (User.Identity.GetUserRole() == "Seller")
            {
                return RedirectToAction("SellerUserProfile", user);
            }
            else 
            {
                return RedirectToAction("BuyerUserProfile", user);
            }
        }

        public ActionResult SellerUserProfile(User user) 
        {
            var products = _productService.GetProducts(user.Id);
            SellerUserProfileVM sellerUserProfileVM = new SellerUserProfileVM()
            {
                User = user,
                Products = products
            };
            return View(sellerUserProfileVM);
        }

        public ActionResult BuyerUserProfile(User user) 
        {
            var orders = _orderService.GetOrders(user.Id);
            BuyerUserProfileVM buyerUserProfileVM = new BuyerUserProfileVM()
            {
                User = user,
                Orders = orders
            };
            return View(buyerUserProfileVM);
        }

    }
}