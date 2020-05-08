using Marketplace.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.BLL.Repositories
{
    public interface ICartRepository
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(int id);
        double CountTotalValue();
        void Clear();
        IEnumerable<CartLine> GetCart();
    }
}
