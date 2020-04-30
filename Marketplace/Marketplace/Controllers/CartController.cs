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
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        // GET: Cart
        public ActionResult CartShow()
        {
            var cart = _cartService.GetCart();
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(ShowProductVM viewModel) 
        {
            //var product = _productService.GetProduct(id);
           // _cartService.AddItem(product, 1);
            return RedirectToAction("ListOfProduct", "Product");
        }


    }
}