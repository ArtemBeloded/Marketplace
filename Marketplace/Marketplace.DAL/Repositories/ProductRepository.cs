using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PagedList;
using Marketplace.DAL.DataBaseContext;

namespace Marketplace.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private MarketplaceContext _marketplaceContext;

        public ProductRepository(MarketplaceContext marketplaceContext)
        {
            _marketplaceContext = marketplaceContext;
        }

        public IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText)
        {
            var products = _marketplaceContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(x => x.Name.ToLower().Contains(searchText.ToLower()) |
                                                    x.Author.ToLower().Contains(searchText.ToLower()));
            }
            return products.ToPagedList(page, itemsPerPage);
        }

        public IEnumerable<Product> GetProducts(int userId) 
        {
            var products = _marketplaceContext.Products.AsQueryable();
            products = products.Where(x => x.UserId == userId);
            return products.ToList();
        }

        public Product GetProduct(int id)
        {

            var product = _marketplaceContext.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public bool AddProduct(Product product)
        {
            _marketplaceContext.Products.Add(product);
            _marketplaceContext.SaveChanges();
            return true;
        }

        public bool RemoveProduct(int id)
        {
            var product = _marketplaceContext.Products.FirstOrDefault(x => x.Id == id);
            _marketplaceContext.Products.Remove(product);
            _marketplaceContext.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var item = _marketplaceContext.Products.Find(product.Id);
            item.Name = product.Name;
            item.Author = product.Author;
            item.Category = product.Category;
            item.Price = product.Price;
            item.Description = product.Description;
            item.Quantity = product.Quantity;
            item.Photo = product.Photo;
            _marketplaceContext.SaveChanges();
            return true;
        }
    }
}
