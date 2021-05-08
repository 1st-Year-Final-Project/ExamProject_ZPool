using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class MyBookingsModel : PageModel
    {
        public UserManager<AppUser> _manager;
        public IBookingService _service;       

        public IEnumerable<Booking> _myBookings;

        public MyBookingsModel(IBookingService service, UserManager<AppUser> manager)
        {
            _service = service;
            _manager = manager;
        }
        
        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            _myBookings = _service.GetBookingsByUser(user.Id);
        }
    }
}
