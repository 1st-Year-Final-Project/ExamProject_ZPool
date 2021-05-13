using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class DeleteUserModel : PageModel
    {
        private SignInManager<AppUser> _SignInManager;
        private UserManager<AppUser> _userManager;
        public ICarService _carService;
        public IBookingService _bookingService;
        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public DeleteUserModel(UserManager<AppUser> userManager, SignInManager<AppUser> SignInManager, ICarService carService, IBookingService bookingService)
        {
            _userManager = userManager;
            _SignInManager = SignInManager;
            _carService = carService;
            _bookingService = bookingService;
        }


        public async Task OnGetAsync()
        {
            LoggedInUser = await _userManager.GetUserAsync(User);

        }

        public void DeleteCars()
        {
           var cars =  _carService.GetCarsByUser(LoggedInUser.Id);
            foreach (var car in cars)
            {
                _carService.DeleteCar(car);
            }
        }
        public IActionResult DeleteBookings()
        {
            var bookings = _bookingService.GetBookingsByUser(LoggedInUser);
            foreach (var booking in bookings)
            {
                _bookingService.DeleteBooking(booking);
            }
            return null;
        }
        



        public async Task<IActionResult> OnPostDelete()
        {
            
            var user = await _userManager.GetUserAsync(User);
            if( user==null)
            {

                return RedirectToPage("./ZPool/Pages/Index.cshtml");
            }
            else
            {
                DeleteBookings();
                DeleteCars();
                await _SignInManager.SignOutAsync();
               

                var result = await _userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("./ZPool/Pages/Index.cshtml");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
               return  RedirectToPage("./ZPool/Pages/Index.cshtml");
            }


            //await _userManager.DeleteAsync(LoggedInUser);


            //return RedirectToPage("./SuccessfullyDeletedAccount");
        }
    }
}

