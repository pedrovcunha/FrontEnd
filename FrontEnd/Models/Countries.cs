using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Addresses = new HashSet<Addresses>();
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
        public ICollection<States> States { get; set; }
    }
}
