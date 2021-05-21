using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class DeleteMyBookingModel : PageModel
    {

        [BindProperty]
        public Booking MyBooking { get; set; }

        public IBookingService _service;

        public DeleteMyBookingModel(IBookingService service)
        {
            _service = service;
            MyBooking = new Booking();
        }
        public void OnGet(int id)
        {
            MyBooking = _service.GetBookingsByID(id);
        }

        public IActionResult OnPost()
        {
            _service.DeleteBooking(MyBooking);

            return RedirectToPage("./MyBookings");
        }

    }
}
