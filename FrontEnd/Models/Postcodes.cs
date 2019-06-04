using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Postcodes
    {
        public Postcodes()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public int? PostCode { get; set; }
        public string Suburb { get; set; }
        public int? StateId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public States State { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
