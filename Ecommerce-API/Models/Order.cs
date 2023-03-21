using System;
using System.Collections.Generic;

namespace Ecommerce_API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? Invoice { get; set; }
        public bool? PendingStatus { get; set; }
        public double BillAmmount { get; set; }
        public int? CustId { get; set; }
        public DateTime DateOfOrder { get; set; }

        public virtual LoginDetail? Cust { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
