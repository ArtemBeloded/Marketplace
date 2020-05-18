using Marketplace.DAL.Models;
using Marketplace.DAL.Repositories;
using PagedList;
using System.Collections.Generic;

namespace Marketplace.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText)
        {
            return _productRepository.GetProducts(page, itemsPerPage, searchText);
        }

        public IEnumerable<Product> GetProducts(int userId) 
        {
            return _productRepository.GetProducts(userId);
        }

        public void RemoveProduct(int id)
        {
            _productRepository.RemoveProduct(id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}

