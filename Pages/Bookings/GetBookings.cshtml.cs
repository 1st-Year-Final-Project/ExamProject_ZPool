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
        public string Message { get; set; }

        public GetBookingsModel(IBookingService service)
        {
            bookingService = service;
        }
        public void OnGet()
        {
            Bookings = bookingService.GetBookings();
        }

        public void OnPostAccept(int id)
        {
            try 
            { 
                bookingService.UpdateBookingStatus(id, "Accepted"); 
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Bookings = bookingService.GetBookings();
        }

        public void OnPostReject(int id)
        {
            try
            {
                bookingService.UpdateBookingStatus(id, "Rejected");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Bookings = bookingService.GetBookings();
        }

        public void OnPostCancel(int id)
        {
            try
            {
                bookingService.UpdateBookingStatus(id, "Cancelled");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            Bookings = bookingService.GetBookings();
        }



    }
}
