using Marketplace.DAL.Models;
using PagedList;
using System.Collections.Generic;

namespace Marketplace.BLL.Services
{
    public interface IProductService
    {
        IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText);
        IEnumerable<Product> GetProducts(int userId);
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool RemoveProduct(int id);
        bool UpdateProduct(Product product);
    }
}
