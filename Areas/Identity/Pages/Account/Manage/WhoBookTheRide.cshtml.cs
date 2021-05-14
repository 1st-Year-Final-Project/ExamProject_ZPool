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
    public class WhoBookTheRideModel : PageModel
    {
        [BindProperty]
        public Ride MyRide { get; set; }
        //public IEnumerable<Booking> BookingsOfOneRide { get; set; }

        public UserManager<AppUser> _maneger;
        //public IBookingService _bookingService;
        public IRideService _rideService;

        public WhoBookTheRideModel(UserManager<AppUser> maneger, /*IBookingService bookingService,*/ IRideService rideService)
        {
            _maneger = maneger;
            //_bookingService = bookingService;
            _rideService = rideService;
        }

        public async Task OnGet(int id)
        {
            AppUser user = await _maneger.GetUserAsync(User);
            MyRide = _rideService.GetRide(id);
        }
    }
}
