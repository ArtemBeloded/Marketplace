﻿using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        bool AddProduct(Product product);
        bool RemoveProduct(Guid id);
        bool UpdateProduct(Product product);
    }
}
