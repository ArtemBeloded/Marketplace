using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAL.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Enter numerical amount")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Enter a valid quantity")]
        public int Quantity { get; set; }

        public string Photo { get; set; }
    }
}
