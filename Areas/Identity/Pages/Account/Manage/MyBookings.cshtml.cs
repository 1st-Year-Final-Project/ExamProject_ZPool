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
        public IBookingService _bookingService;
        public IEnumerable<Booking> MyBookings { get; set; }
        public string Message { get; set; }


        public MyBookingsModel(IBookingService service, UserManager<AppUser> manager)
        {
            _bookingService = service;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            MyBookings = _bookingService.GetBookingsByUser(user);
        }

        public async Task OnPostCancel(int id)
        {
            AppUser user = await _manager.GetUserAsync(User);
            MyBookings = _bookingService.GetBookingsByUser(user);
            //MyBookings = _bookingService.GetBookings();

            try
            {
                _bookingService.UpdateBookingStatus(id, "Cancelled");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            //reconstruc the data senario            

            //await LoadBookingByRideId(rideId);
            //MyRide = _rideService.GetRide(rideId);

            RedirectToPage("MyBookings");
        }


    }
}
