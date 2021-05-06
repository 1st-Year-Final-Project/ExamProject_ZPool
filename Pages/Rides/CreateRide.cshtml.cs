using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Rides
{
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }
       
        IRideService rideService;

        public CreateRideModel( IRideService service)
        {
            this.rideService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync (Ride ride)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            rideService.AddRide(ride);
            return RedirectToPage("GetAllRides");
             
        }

    }
}
