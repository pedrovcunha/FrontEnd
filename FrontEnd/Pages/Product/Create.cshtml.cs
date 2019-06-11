using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEnd.Models;

namespace FrontEnd.Pages.Product
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
        ViewData["BrandCategoryId"] = new SelectList(_context.BrandCategory, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}