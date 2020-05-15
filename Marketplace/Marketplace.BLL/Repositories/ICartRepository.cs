using Marketplace.DAL.Models;
using System.Collections.Generic;

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
