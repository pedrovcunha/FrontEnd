using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEnd.Models;

namespace FrontEnd.Pages.SaleRepresentative
{
    public class CreateModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public CreateModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonId"] = new SelectList(_context.People, "Id", "FirstName");
        ViewData["PromotionAgencyId"] = new SelectList(_context.PromotionalAgencies, "Id", "Name");
        ViewData["RetailStoreId"] = new SelectList(_context.RetailStores, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SalesRepresentatives SalesRepresentatives { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesRepresentatives.Add(SalesRepresentatives);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}