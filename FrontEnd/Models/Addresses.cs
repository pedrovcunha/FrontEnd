using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            People = new HashSet<People>();
            PromotionalAgencies = new HashSet<PromotionalAgencies>();
            RetailStores = new HashSet<RetailStores>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public int? PostCodeId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public Countries Country { get; set; }
        public Postcodes PostCode { get; set; }
        public States State { get; set; }
        public ICollection<People> People { get; set; }
        public ICollection<PromotionalAgencies> PromotionalAgencies { get; set; }
        public ICollection<RetailStores> RetailStores { get; set; }
    }
}
