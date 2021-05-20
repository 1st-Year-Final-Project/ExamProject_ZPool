using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
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
        private IMessageService _messageService;

        public RideModel(IRideService rideService, 
            UserManager<AppUser> userServise, 
            IBookingService bookingService, 
            IMessageService messageService)
        {
            _rideService = rideService;
            _userManager = userServise;
            _bookingService = bookingService;
            _messageService = messageService;
        }
        
        public Ride Ride { get; set; }

        public int RideId { get; set; }

        public AppUser CurrentUser { get; set; }

        public Message Message { get; set; }

        public int SeatsLeft { get; set; }

        public async Task OnGetAsync(int id)
        {
            Ride = _rideService.GetRide(id);
            RideId = id;
            SeatsLeft = _rideService.SeatsLeft(RideId);
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

        public IActionResult OnPostDelete(int rideId)
        {
            Ride ride = _rideService.GetRide(rideId);
            _rideService.DeleteRide(ride);
            return RedirectToPage("/Rides/GetAllRides");
        }

        public async Task<IActionResult> OnPostSend()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Message.SendingDate = DateTime.Now;
            _messageService.CreateMessage(Message);
            return RedirectToPage("/Rides/Ride", new { id = RideId});
        }
    }
}
