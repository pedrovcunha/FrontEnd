using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class SalesRepresentatives
    {
        public SalesRepresentatives()
        {
            Orders = new HashSet<Orders>();
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string JobTitle { get; set; }
        public int? PromotionAgencyId { get; set; }
        public int? RetailStoreId { get; set; }

        public PromotionalAgencies PromotionAgency { get; set; }
        public RetailStores RetailStore { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
