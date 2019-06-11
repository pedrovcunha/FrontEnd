using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Models;

namespace FrontEnd.Pages.SaleRepresentative
{
    public class DeleteModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public DeleteModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesRepresentatives SalesRepresentatives { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesRepresentatives = await _context.SalesRepresentatives
                .Include(s => s.Person)
                .Include(s => s.PromotionAgency)
                .Include(s => s.RetailStore).FirstOrDefaultAsync(m => m.Id == id);

            if (SalesRepresentatives == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesRepresentatives = await _context.SalesRepresentatives.FindAsync(id);

            if (SalesRepresentatives != null)
            {
                _context.SalesRepresentatives.Remove(SalesRepresentatives);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
