using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }
        IBookingService bookingservice;
        public CreateModel(IBookingService service)
        {
            bookingservice = service;
        }

        public IActionResult OnGet()
        {
            return Page();
         }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           bookingservice.AddBooking(Booking);
           return RedirectToPage();
        }
    }
}
