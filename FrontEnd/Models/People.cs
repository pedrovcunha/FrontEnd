using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class People
    {
        public People()
        {
            BrandCategory = new HashSet<BrandCategory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }

        public Addresses Address { get; set; }
        public ICollection<BrandCategory> BrandCategory { get; set; }
    }
}
