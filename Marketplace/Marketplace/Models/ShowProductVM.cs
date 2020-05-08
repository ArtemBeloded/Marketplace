using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class ShowProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string LongDescription { get; set; }

        public string ShortDescription { get; set; }

        public int Quantity { get; set; }

        public string Photo { get; set; }
    }
}