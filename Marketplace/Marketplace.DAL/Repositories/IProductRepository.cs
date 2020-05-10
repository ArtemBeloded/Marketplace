using Marketplace.DAL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAL.Repositories
{
    public interface IProductRepository
    {
        IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText);
        IEnumerable<Product> GetProducts(int userId);
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool RemoveProduct(int id);
        bool UpdateProduct(Product product);
    }
}
