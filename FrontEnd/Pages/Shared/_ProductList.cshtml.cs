using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Pages.Shared
{
    public class _ProductListModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public _ProductListModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var products = _context.Products;
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; }
        
    }
}