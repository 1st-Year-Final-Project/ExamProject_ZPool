using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Bookings
{
    public class GetBookingsModel : PageModel
    {
        IBookingService bookingService;
        public IEnumerable<Booking> Bookings{ get; set; }

        public GetBookingsModel(IBookingService service)
        {
            bookingService = service;
        }
        public void OnGet()
        {
            Bookings = bookingService.GetBookings();
        }
    }
}
