using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class BrandCategory
    {
        public BrandCategory()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BrandManagerId { get; set; }

        public People BrandManager { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
