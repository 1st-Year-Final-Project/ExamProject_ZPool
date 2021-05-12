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

namespace ZPool.Pages.Bookings
{
    public class GetBookingsModel : PageModel
    {
        IBookingService bookingService;
        UserManager<AppUser> userManager;

        public IEnumerable<Booking> Bookings{ get; set; }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public string Message { get; set; }

        public GetBookingsModel(IBookingService service, UserManager<AppUser> manager)
        {
            bookingService = service;
            userManager = manager;
        }
        public async Task OnGet()
        {
            Bookings = bookingService.GetBookings();
            LoggedInUser = await userManager.GetUserAsync(User);
        }

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
            RedirectToPage("GetBookings");

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
            RedirectToPage("GetBookings");
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
            RedirectToPage("GetBookings");
        }
    }
}
