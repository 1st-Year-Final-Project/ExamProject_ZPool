using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZPool.Models;

namespace ZPool.Pages.Notification
{
    public class GetNotificationModel : PageModel
    {
        
        AppDbContext _context;

        public IEnumerable Rides { get; set; }

        public async Task OnGetAsync()
        {
            Rides = await _context.Rides
                    .Select(r => new
                    {
                        r.Bookings,
                    })
                    .ToListAsync();

        }

    }
}
