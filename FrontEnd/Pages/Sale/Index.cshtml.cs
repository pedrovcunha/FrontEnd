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
    public class IndexModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public IndexModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public IList<Sales> Sales { get;set; }

        public async Task OnGetAsync()
        {
            Sales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.RetailStore)
                .Include(s => s.SalesRepresentative)
                .Include(s => s.SalesRepresentative.Person).ToListAsync();
        }
    }
}
