using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VisioForge.Shared.MediaFoundation.OPM;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Notification
{
    [Authorize]
    public class GetNotificationModel : PageModel
    {
        IRideService rideService;
        IBookingService bookingService;
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Ride> Rides { get; set; }
        public UserManager<AppUser> _userManager;
        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public string Message { get; set; }


        public GetNotificationModel(IBookingService serviceForBooking, IRideService serviceForRides, UserManager<AppUser> userManager)
        {
            bookingService = serviceForBooking;
            rideService = serviceForRides;
            _userManager = userManager;

        }
        public async Task OnGetAsync()
        {
            //LoggedInUser = await _userManager.GetUserAsync(User);
            //Rides = rideService.GetAllRides().Where(r=>r.Car.AppUserID== LoggedInUser.Id);
            //Bookings = bookingService.GetBookings().Where(b=>b.AppUserID== LoggedInUser.Id);
            Bookings = bookingService.GetBookings();
            LoggedInUser = await _userManager.GetUserAsync(User);

        }
        //public void OnGet()
        //{


        //}

        public void OnPostAccept(int id)
        {
            Bookings = bookingService.GetBookings();

            try
            {
                bookingService.UpdateBookingStatus(id, "Accepted");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");

        }

        public void OnPostReject(int id)
        {
            Bookings = bookingService.GetBookings();

            try
            {
                bookingService.UpdateBookingStatus(id, "Rejected");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");
        }

        public void OnPostCancel(int id)
        {
            Bookings = bookingService.GetBookings();

            try
            {
                bookingService.UpdateBookingStatus(id, "Cancelled");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");
        }
    }
}
