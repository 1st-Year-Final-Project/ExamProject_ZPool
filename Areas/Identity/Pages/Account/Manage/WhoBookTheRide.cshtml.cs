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
        [BindProperty] public Ride MyRide { get; set; }
        //[BindProperty] public string UserAvatarName { get; set; }
        public IEnumerable<Booking> BookingsOfOneRide { get; set; }
        public UserManager<AppUser> _maneger;
        public IBookingService _bookingService;
        public IRideService _rideService;
        public string Message { get; set; }
        

        public WhoBookTheRideModel(UserManager<AppUser> maneger, IBookingService bookingService, IRideService rideService)
        {
            _maneger = maneger;
            _bookingService = bookingService;
            _rideService = rideService;
        }

        public async Task OnGetAsync(int id)
        {
            AppUser user = await _maneger.GetUserAsync(User);
            MyRide = _rideService.GetRide(id);

            await LoadBookingByRideId(id);
        }

        private async Task LoadBookingByRideId(int rideId)
        {
            List<Booking> bookings = _bookingService.GetBookingsByRideId(rideId).ToList();

            //loading dependent AppUser for each Booking
            foreach (Booking booking in bookings)
            {
                int appUserId = booking.AppUserID;

                await _maneger.FindByIdAsync(appUserId.ToString());
            }

            BookingsOfOneRide = bookings;
        }

        private int GetRideIdFromBooking(int bookingId)
        {
            Booking currentBooking = _bookingService.GetBookingsByID(bookingId);
            return currentBooking.RideID;
        }

        public async Task OnPostAccept(int id)
        {
            try
            {
                _bookingService.UpdateBookingStatus(id, "Accepted");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            //reconstruc the data senario            
            int rideId = GetRideIdFromBooking(id);
            await LoadBookingByRideId(rideId);
            MyRide = _rideService.GetRide(rideId);

            RedirectToPage("WhoBookTheRide");
        }

        public async Task OnPostReject(int id)
        {
            try
            {
                _bookingService.UpdateBookingStatus(id, "Rejected");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            //reconstruc the data senario            
            int rideId = GetRideIdFromBooking(id);
            await LoadBookingByRideId(rideId);
            MyRide = _rideService.GetRide(rideId);

            RedirectToPage("WhoBookTheRide");
        }

        public async Task OnPostCancel(int id)
        {
            try
            {
                _bookingService.UpdateBookingStatus(id, "Cancelled");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            //reconstruc the data senario            
            int rideId = GetRideIdFromBooking(id);
            await LoadBookingByRideId(rideId);
            MyRide = _rideService.GetRide(rideId);

            RedirectToPage("WhoBookTheRide");
        }
       
    }

}
