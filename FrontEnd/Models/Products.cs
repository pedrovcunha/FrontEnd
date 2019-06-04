using System;
using System.Collections.Generic;

namespace FrontEnd.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderProducts = new HashSet<OrderProducts>();
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? BrandCategoryId { get; set; }
        public int? Size { get; set; }

        public BrandCategory BrandCategory { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
