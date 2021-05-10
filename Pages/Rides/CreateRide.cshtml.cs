using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using ZPool.Models;
using ZPool.Services.Interface;
using UserManagementTestApp.Models;

namespace ZPool.Pages.Rides
{
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }
        public SelectList registeredCars { get; set; }
       
        IRideService rideService;
        UserManager<AppUser> userManager;

        public CreateRideModel( IRideService service, UserManager<AppUser> manager)
        {
            this.rideService = service;
            userManager = manager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await userManager.GetUserAsync(User);
            registeredCars = new SelectList(rideService.GetRegisteredCars(user.Id), "CarID", "NumberPlate");
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
