using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Models;

namespace FrontEnd.Pages.Sale
{
    public class EditModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public EditModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                .Include(s => s.SalesRepresentative)
                .Include(s => s.SalesRepresentative.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (Sales == null)
            {
                return NotFound();
            }
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
           ViewData["RetailStoreId"] = new SelectList(_context.RetailStores, "Id", "Name");
           ViewData["SalesRepresentativeId"] = new SelectList(_context.SalesRepresentatives.Include(s => s.Person), "Id", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(Sales.Id))
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

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
