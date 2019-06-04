using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Models;

namespace FrontEnd.Pages.Sale
{
    public class DetailsModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public DetailsModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public Sales Sales { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.RetailStore)
                .Include(s => s.SalesRepresentative).FirstOrDefaultAsync(m => m.Id == id);

            if (Sales == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
