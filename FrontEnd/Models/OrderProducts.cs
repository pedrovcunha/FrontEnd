using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class OrderProducts
    {
        public int OrderOrderId { get; set; }
        public int ProductProductId { get; set; }

        public Orders OrderOrder { get; set; }
        public Products ProductProduct { get; set; }
    }
}
