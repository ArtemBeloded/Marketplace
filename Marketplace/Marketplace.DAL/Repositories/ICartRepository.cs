using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAL.Repositories
{
    public interface ICartRepository
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(Guid id);
        double CountTotalValue();
        void Clear();
        IEnumerable<CartLine> GetCart();
    }
}
