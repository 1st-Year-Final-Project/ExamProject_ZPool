using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Bookings
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Booking booking { get; set; }
        IBookingService bookingservice;
        public EditModel(IBookingService service)
        {
            bookingservice = service;
        }

        public IActionResult OnGet(int id)
        {
            booking = bookingservice.GetBookingsByID(id);
            if (booking == null)
            {
                return null;
            }
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingservice.EditBooking(booking);
            return RedirectToPage();
        }
    }
}

//        private readonly ZPool.Models.AppDbContext _context;

//        public EditModel(ZPool.Models.AppDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Booking Booking { get; set; }

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Booking = await _context.Bookings
//                .Include(b => b.AppUser)
//                .Include(b => b.Ride).FirstOrDefaultAsync(m => m.BookingID == id);

//            if (Booking == null)
//            {
//                return NotFound();
//            }
//           ViewData["AppUserID"] = new SelectList(_context.Users, "Id", "FirstName");
//           ViewData["RideID"] = new SelectList(_context.Rides, "RideID", "RideID");
//            return Page();
//        }

//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(Booking).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!BookingExists(Booking.BookingID))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool BookingExists(int id)
//        {
//            return _context.Bookings.Any(e => e.BookingID == id);
//        }
//    }
//}
