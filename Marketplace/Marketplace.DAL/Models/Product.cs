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
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Photo { get; set; }

        public int UserId { get; set; }

        public User Owner { get; set; }
    }
}
