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
using Sentry.Protocol;
using VisioForge.Shared.MediaFoundation.OPM;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Notification
{
    [Authorize]
    public class GetNotificationModel : PageModel
    {
        
        private IBookingService _bookingService;
        private UserManager<AppUser> _userManager;

        public List<Booking> Bookings { get; set; }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public string Message { get; set; }


        public GetNotificationModel(IBookingService serviceForBooking, UserManager<AppUser> userManager)
        {
            _bookingService = serviceForBooking;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            LoggedInUser = await _userManager.GetUserAsync(User);
            Bookings = new List<Booking>();

            foreach (var booking in _bookingService.GetBookingsByDriversID(LoggedInUser))
            {
                Bookings.Add(booking);
            }

            foreach (var booking in _bookingService.GetBookingsByUser(LoggedInUser))
            {
                Bookings.Add(booking);
            }
            
        }

        public void OnPostAccept(int id)
        {
            Bookings = _bookingService.GetBookings().ToList();

            try
            {
                _bookingService.UpdateBookingStatus(id, "Accepted");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");

        }

        public void OnPostReject(int id)
        {
            Bookings = _bookingService.GetBookings().ToList();

            try
            {
                _bookingService.UpdateBookingStatus(id, "Rejected");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");
        }

        public void OnPostCancel(int id)
        {
            Bookings = _bookingService.GetBookings().ToList();

            try
            {
                _bookingService.UpdateBookingStatus(id, "Cancelled");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            RedirectToPage("GetNotification");
        }
    }
}
