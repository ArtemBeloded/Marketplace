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
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IProductService _productService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IProductService productService, IMapper mapper)
        {
            _cartService = cartService;
            _productService = productService;
            _mapper = mapper;
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

        public ActionResult RemoveItem(Guid id) 
        {
            _cartService.RemoveItem(id);
            return RedirectToAction("CartShow", "Cart");
        }

        public ActionResult Purchase() 
        {
            _cartService.Clear();
            return RedirectToAction("ListOfProduct", "Product");
        }


    }
}