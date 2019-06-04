using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEnd.Models;

namespace FrontEnd.Pages.Sale
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
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
        ViewData["RetailStoreId"] = new SelectList(_context.RetailStores, "Id", "Name");
        ViewData["SalesRepresentativeId"] = new SelectList(_context.People, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Sales Sales { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this.Sales.SalesRepresentative = _context.SalesRepresentatives.Where(p => p.PersonId == Sales.SalesRepresentativeId).FirstOrDefault();
            _context.Sales.Add(Sales);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}