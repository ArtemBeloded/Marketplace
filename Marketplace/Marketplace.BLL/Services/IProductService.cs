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
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool RemoveProduct(int id);
        bool UpdateProduct(Product product);
    }
}
