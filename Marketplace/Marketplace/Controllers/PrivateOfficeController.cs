using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
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

        public PrivateOfficeController(IProductService productService, IMapper mapper, IUserService userService)
        {
            _productService = productService;
            _mapper = mapper;
            _userService = userService;
        }

        public ActionResult UserProfile()
        {
            var user = _userService.GetUser(HttpContext.User.Identity.Name);
            if (user.Role == "Seller")
            {
                return RedirectToAction("SellerUserProfile", user);
            }
            else 
            {

            }

            return View();
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

    }
}