using System;
using System.Collections.Generic;

namespace Ecommerce_API.Models
{
    public partial class LoginDetail
    {
        public LoginDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string? Username { get; set; }
        public string Pwd { get; set; } = null!;
        public int Cid { get; set; }
        public string? Cname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
