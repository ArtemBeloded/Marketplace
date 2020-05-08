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
            using (_marketplaceContext) 
            {
                var products = _marketplaceContext.Products.AsQueryable();
                if (!string.IsNullOrEmpty(searchText))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchText.ToLower()) |
                                                        x.Author.ToLower().Contains(searchText.ToLower()));
                }
                return products.ToPagedList(page, itemsPerPage);
            }
        }

        public Product GetProduct(int id)
        {
            using (_marketplaceContext) 
            {
                var product = _marketplaceContext.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
        }

        public bool AddProduct(Product product)
        {
            using (_marketplaceContext) 
            {
                _marketplaceContext.Products.Add(product);
                
                return true;
            }
        }

        public bool RemoveProduct(int id)
        {
            using (_marketplaceContext) 
            {
                var product = _marketplaceContext.Products.FirstOrDefault(x => x.Id == id);
                _marketplaceContext.Products.Remove(product);
                _marketplaceContext.SaveChanges();
                return true;
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (_marketplaceContext) 
            {
                var item = _marketplaceContext.Products.FirstOrDefault(x => x.Id == product.Id);
                item = product;
                _marketplaceContext.SaveChanges();
                return true;
            }
        }
    }
}
