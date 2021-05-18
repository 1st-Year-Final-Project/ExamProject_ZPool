using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Services.Interface;

namespace UserManagementTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IRideService rideService;

        public IEnumerable<Ride> Rides { get; set; }

        [BindProperty(SupportsGet = true)]
        public Ride RideCriteria { get; set; } = new Ride();

        public string ScreenMessage { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IRideService service)
        {
            _logger = logger;
            rideService = service;

        }
        

        public void OnGet()
        {
            //if (!string.IsNullOrEmpty(RideCriteria.DepartureLocation) || !string.IsNullOrEmpty(RideCriteria.DestinationLocation))
            //{
            //    Rides = rideService.FilterRides(RideCriteria);
            //    if (Rides.Count() == 0)
            //    {
            //        ScreenMessage = "Sorry! We couldn't match any rides to your request.";
            //    }
            //}
            //else
            //{
            //    Rides = rideService.GetAllRides();
                RideCriteria.StartTime = DateTime.Now;
                
            //}
        }
        public IActionResult OnPost()
        {
                


               return RedirectToPage("/Rides/GetAllRides",RideCriteria);
        }

    }
}
