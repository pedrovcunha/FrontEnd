using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Models;

namespace FrontEnd.Pages.SaleRepresentative
{
    public class EditModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public EditModel(FrontEnd.Models.salestrackerdbContext context)
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
           ViewData["PersonId"] = new SelectList(_context.People, "Id", "FullName");
           ViewData["PromotionAgencyId"] = new SelectList(_context.PromotionalAgencies, "Id", "Name");
           ViewData["RetailStoreId"] = new SelectList(_context.RetailStores, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalesRepresentatives).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRepresentativesExists(SalesRepresentatives.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalesRepresentativesExists(int id)
        {
            return _context.SalesRepresentatives.Any(e => e.Id == id);
        }
    }
}
