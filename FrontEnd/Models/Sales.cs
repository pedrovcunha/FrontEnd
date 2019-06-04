using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int? SalesRepresentativeId { get; set; }
        public int? RetailStoreId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Comission { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public Products Product { get; set; }
        public RetailStores RetailStore { get; set; }
        public SalesRepresentatives SalesRepresentative { get; set; }
    }
}
