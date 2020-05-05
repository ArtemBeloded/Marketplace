using Marketplace.DAL.Models;
using Marketplace.DAL.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.GetProduct(id);
        }

        public IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText)
        {
            return _productRepository.GetProducts(page, itemsPerPage, searchText);
        }


        public IEnumerable<Product> GetProductsByCategory(int category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

        public bool RemoveProduct(Guid id)
        {
            return _productRepository.RemoveProduct(id);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}

