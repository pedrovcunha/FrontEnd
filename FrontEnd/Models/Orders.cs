using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int Id { get; set; }
        public int SalesRepresentativeId { get; set; }
        public int? RetailStoreId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Commission { get; set; }

        public RetailStores RetailStore { get; set; }
        public SalesRepresentatives SalesRepresentative { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
