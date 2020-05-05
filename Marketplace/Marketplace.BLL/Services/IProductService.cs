using Marketplace.DAL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Services
{
    public interface IProductService
    {
        IPagedList<Product> GetProducts(int page, int itemsPerPage, string searchText);
        IEnumerable<Product> GetProductsByCategory(int category);
        Product GetProduct(Guid id);
        bool AddProduct(Product product);
        bool RemoveProduct(Guid id);
        bool UpdateProduct(Product product);
    }
}
