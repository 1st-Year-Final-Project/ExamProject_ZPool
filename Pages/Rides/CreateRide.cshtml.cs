using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using ZPool.Models;
using ZPool.Services.Interfaces;
using System.Globalization;

namespace ZPool.Pages.Rides
{
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }
        public SelectList registeredCars { get; set; }
        public string Message { get; set; }
        public CultureInfo culture { get; set; } //Created culture property to use in the formatting of date & time.

        IRideService rideService;
        ICarService carService;
        UserManager<AppUser> userManager;
        
        public CreateRideModel( IRideService service, ICarService carService, UserManager<AppUser> manager)
        {
            this.rideService = service;
            userManager = manager;
            this.carService = carService;
        }

       
        public async Task<IActionResult> OnGet()
        {
            culture = new CultureInfo("en-US"); //setting culture object to US English. Date filters are picky.
            var user = await userManager.GetUserAsync(User); // will throw exception if not logged in          
            registeredCars = new SelectList(rideService.GetRegisteredCars(user.Id), "CarID", "NumberPlate");
            return Page();
        }

        public async Task<IActionResult> OnPost(Ride ride)
        {

            if (!ModelState.IsValid)

            {
                return Page();
            }
            Car car = carService.GetCar(ride.CarID);
            if (ride.SeatsAvailable <= car.NumberOfSeats)
            {
                rideService.AddRide(ride);
                return RedirectToPage("GetAllRides");
            }
            else
            {
                var user = await userManager.GetUserAsync(User);
                registeredCars = new SelectList(rideService.GetRegisteredCars(user.Id), "CarID", "NumberPlate");
                Message = "The seats available cannot exceed the number of seats in your car.";
                return Page();
            }

        }

    }
}
