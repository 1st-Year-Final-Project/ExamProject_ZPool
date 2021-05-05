using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZPool.Models;

namespace ZPool.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ZPool.Models.AppDbContext _context;

        public IndexModel(ZPool.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Bookings
                .Include(b => b.AppUser)
                .Include(b => b.Ride).ToListAsync();
        }
    }
}
