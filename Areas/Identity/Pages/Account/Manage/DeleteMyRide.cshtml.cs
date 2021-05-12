using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class DeleteMyRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }

        public IRideService _service;

        public DeleteMyRideModel(IRideService service)
        {
            _service = service;
            Ride = new Ride();
        }
        public void OnGet(int id)
        {
            Ride = _service.GetRide(id);
        }

        public IActionResult OnPost()
        {
            _service.DeleteRide(Ride);

            return RedirectToPage("./MyRides");
        }



    }
}
