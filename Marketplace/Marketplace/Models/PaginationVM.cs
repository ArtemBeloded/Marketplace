using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class PaginationVM
    {
        public IEnumerable<ShowProductVM> Products { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItems {get; set;}

        public int TotalPages 
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}