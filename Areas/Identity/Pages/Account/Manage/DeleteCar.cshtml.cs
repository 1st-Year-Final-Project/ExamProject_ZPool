using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class DeleteCarModel : PageModel
    {
        [BindProperty]
        public Car Car { get; set; }

        ICarService carService;
        IRideService _rideService;
        public DeleteCarModel(ICarService service, IRideService rideService)
        {
            this.carService = service;
            Car = new Car();
            _rideService = rideService;
        }
        public void OnGet(int id)
        {
            Car = carService.GetCar(id);
        }
        public IActionResult OnPost()
        {
            if(Car.Rides.Count>0)
            {
                foreach (var ride in Car.Rides)
                {
                    _rideService.DeleteRide(ride);

                }
            }
            carService.DeleteCar(Car);

            return RedirectToPage("./MyCars");
        }
    }
}
