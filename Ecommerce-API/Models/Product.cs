using System;
using System.Collections.Generic;

namespace Ecommerce_API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Pid { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? ScType { get; set; }
        public string? Size { get; set; }
        public int? BrandId { get; set; }
        public int? InStock { get; set; }
        public double? Price { get; set; }
        public string? Imglink { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
