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
    public class MyRidesModel : PageModel
    {
        public UserManager<AppUser> _manager;
        public IRideService _service;

        public IEnumerable<Ride> _myRides;

        public MyRidesModel(UserManager<AppUser> manager, IRideService service)
        {
            _service = service;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            _myRides = _service.GetRidesByUser(user);
        }
    }
}
