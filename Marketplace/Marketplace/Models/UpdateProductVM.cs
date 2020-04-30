using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class UpdateProductVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Photo { get; set; }
    }
}