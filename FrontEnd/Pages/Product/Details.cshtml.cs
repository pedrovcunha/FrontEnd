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
    public class DetailsModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public DetailsModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.Products
                .Include(p => p.BrandCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
