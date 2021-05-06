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
    public class CreateCarModel : PageModel
    {


        [BindProperty]
        public Car Car { get; set; }

        ICarService carService;
        private UserManager<AppUser> _userManager;

        public CreateCarModel(ICarService service, UserManager<AppUser> userManager)
        {
            this.carService = service;
            _userManager = userManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(Car car)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            car.AppUserID = user.Id;
            carService.AddCar(car);
            return RedirectToPage("MyCars");
        }
    }
}
