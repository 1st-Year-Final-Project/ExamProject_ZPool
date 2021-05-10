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
    public class GetAllRidesModel : PageModel
    {
        IRideService rideService;

        public IEnumerable<Ride> Rides { get; set; }

        [BindProperty(SupportsGet = true)]
        public Ride RideCriteria { get; set; } = new Ride();

        public string ScreenMessage { get; set; }

        public GetAllRidesModel(IRideService service)
        {
            rideService = service;
        }
        
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(RideCriteria.DepartureLocation) || !string.IsNullOrEmpty(RideCriteria.DestinationLocation))
            {
                Rides = rideService.FilterRides(RideCriteria);
                if (Rides.Count() == 0)
                {
                    ScreenMessage = "Sorry! We couldn't match any rides to your request.";
                }
            }
            else
            {
                Rides = rideService.GetAllRides();
                RideCriteria.StartTime = DateTime.Now;
            }
        }
    }
}
