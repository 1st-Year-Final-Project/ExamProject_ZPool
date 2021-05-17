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

namespace ZPool.Pages.Rides
{
    [BindProperties]
    public class RideModel : PageModel
    {
        private IRideService _rideService;
        private UserManager<AppUser> _userManager;
        private IBookingService _bookingService;

        public RideModel(IRideService rideService, UserManager<AppUser> userServise, IBookingService bookingService)
        {
            _rideService = rideService;
            _userManager = userServise;
            _bookingService = bookingService;
        }
        
        public Ride Ride { get; set; }

        public int RideId { get; set; }

        public AppUser CurrentUser { get; set; }

        public async Task OnGetAsync(int id)
        {
            Ride = _rideService.GetRide(id);
            RideId = id;
            CurrentUser = await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            Ride ride = _rideService.GetRide(RideId);

            if (user != null && ride != null)
            {
                Booking booking = new Booking();
                booking.Date = DateTime.Now;
                booking.PickUpLocation = ride.DepartureLocation;
                booking.DropOffLocation = ride.DestinationLocation;
                booking.RideID = ride.RideID;
                booking.AppUserID = user.Id;
                booking.BookingStatus = "Pending";
                _bookingService.AddBooking(booking);
            }
            
            return RedirectToPage("/Account/Manage/MyBookings", new { area = "Identity" });
        }

        public void OnPostDelete(int rideId)
        {
            Ride ride = _rideService.GetRide(rideId);
            _rideService.DeleteRide(ride);
            RedirectToPage("/GetAllRides");
        }
    }
}
