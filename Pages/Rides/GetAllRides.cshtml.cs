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
        
        public GetAllRidesModel(IRideService service)
        {
            rideService = service;
        }
        
        public void OnGet()
        {
            Rides = rideService.GetAllRides();
        }
    }
}
