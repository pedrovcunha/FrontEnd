using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Models;

namespace FrontEnd.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public IndexModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Include(p => p.BrandCategory).ToListAsync();
        }
    }
}
