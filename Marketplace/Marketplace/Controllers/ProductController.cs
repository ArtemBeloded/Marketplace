using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        // GET: Product
        public ActionResult ListOfProduct(string currentSearch, int page = 1, int count = 10, string searchText = null)
        {
            if (searchText == null) 
            {
                searchText = currentSearch;
            }
            ViewBag.SearchText = searchText;
            var products = _productService.GetProducts(page, count, searchText);


            return View(products);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewBook(ProductViewModel productView)
        {
            Product product = _mapper.Map<Product>(productView);
            _productService.AddProduct(product);
            return RedirectToAction("ListOfProduct");
        }

        public ActionResult EditProduct(int id)
        {
            var product = _mapper.Map<UpdateProductVM>(_productService.GetProduct(id));
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(UpdateProductVM updateProduct, HttpPostedFileBase photoFile)
        {
            if (photoFile != null)
            {
                byte[] imageArray = new byte[photoFile.ContentLength];
                photoFile.InputStream.Read(imageArray, 0, photoFile.ContentLength);

                updateProduct.Photo = Convert.ToBase64String(imageArray);
            }
            var product = _mapper.Map<Product>(updateProduct);
            _productService.UpdateProduct(product);
            return RedirectToAction("ListOfProduct");
        }

        public ActionResult ProductDetail(int id) 
        {
            var product = _mapper.Map<ShowProductVM>(_productService.GetProduct(id));
            return View(product);
        }




        //[HttpPost]
        //public ActionResult DeleteProduct(Guid id)
        //{
        //	_productService.DeleteProduct(id);
        //	return RedirectToAction("ListOfProduct");
        //}
    }
}