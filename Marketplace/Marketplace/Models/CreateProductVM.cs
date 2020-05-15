using System.Web;

namespace Marketplace.Models
{
    public class CreateProductVM
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public CategoryVM Category { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}