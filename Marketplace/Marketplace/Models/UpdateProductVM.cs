﻿namespace Marketplace.Models
{
    public class UpdateProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public CategoryVM Category { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Photo { get; set; }

        public int UserId { get; set; }
    }
}