using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Rides
{
    public class DeleteRideModel : PageModel
    {
        IRideService rideService;

        [BindProperty]
        public Ride Ride { get; set; }

        public DeleteRideModel (IRideService service)
        {
            rideService = service;
        }
        public IActionResult OnGet(int id)
        {
            Ride = rideService.GetRide(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if(id == Ride.RideID)
            {
                rideService.DeleteRide(id);
            }
            return RedirectToPage();
        }
    }
}
