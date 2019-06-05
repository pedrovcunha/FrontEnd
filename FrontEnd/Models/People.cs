using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string FullName { get {
                return $"{FirstName} {SurName}";
            }
        }
        public ICollection<BrandCategory> BrandCategory { get; set; }
    }
}
