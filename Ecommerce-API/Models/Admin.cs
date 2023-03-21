using System;
using System.Collections.Generic;

namespace Ecommerce_API.Models
{
    public partial class Admin
    {
        public int Aid { get; set; }
        public string? Username { get; set; }
        public string Pwd { get; set; } = null!;
    }
}
