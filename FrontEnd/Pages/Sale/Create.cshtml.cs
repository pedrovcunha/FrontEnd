using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEnd.Models;
using Microsoft.EntityFrameworkCore;

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
        ViewData["SalesRepresentativeId"] = new SelectList(_context.SalesRepresentatives.Include(s => s.Person), "Id", "FullName");

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
            
            // Calculate the total Value of the Sale
            var product = _context.Products.Find(Sales.ProductId);
            this.Sales.TotalPrice = product.Price * Sales.Quantity.Value;

            _context.Sales.Add(Sales);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}