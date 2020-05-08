﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }
    }
}
