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
    public class IndexModel : PageModel
    {
        private readonly FrontEnd.Models.salestrackerdbContext _context;

        public IndexModel(FrontEnd.Models.salestrackerdbContext context)
        {
            _context = context;
        }

        public IList<SalesRepresentatives> SalesRepresentatives { get;set; }

        public async Task OnGetAsync()
        {
            SalesRepresentatives = await _context.SalesRepresentatives
                .Include(s => s.Person)
                .Include(s => s.PromotionAgency)
                .Include(s => s.RetailStore).ToListAsync();
        }
    }
}
