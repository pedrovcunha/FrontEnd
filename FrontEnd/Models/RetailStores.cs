using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class RetailStores
    {
        public RetailStores()
        {
            Orders = new HashSet<Orders>();
            Sales = new HashSet<Sales>();
            SalesRepresentatives = new HashSet<SalesRepresentatives>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }

        public Addresses Address { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Sales> Sales { get; set; }
        public ICollection<SalesRepresentatives> SalesRepresentatives { get; set; }
    }
}
