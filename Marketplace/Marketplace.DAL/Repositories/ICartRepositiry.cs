using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAL.Repositories
{
    public interface ICartRepositiry
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(Product product);
        double CountTotalValue();
        void Clear();
        IEnumerable<CartLine> GetCart();
    }
}
