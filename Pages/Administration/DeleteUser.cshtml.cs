using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Administration
{
    public class DeleteUserModel : PageModel
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private ICarService _carService;
        private IMessageService _messageService;

        public DeleteUserModel(UserManager<AppUser> userManager,
            ICarService carService,
            IMessageService messageService)
        {
            _userManager = userManager;
            _carService = carService;
            _messageService = messageService;
        }

        [BindProperty]
        public AppUser AppUser { get; set; }

        public async Task OnGetAsync(int userId)
        {
            AppUser = await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<IActionResult> OnPostDeleteAsync(int userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var car in _carService.GetCarsByUser(user.Id))
            {
                _carService.DeleteCar(car);
            }
            _messageService.DeleteMessagesByUserId(user.Id);

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) return Page();

            return RedirectToPage("/Administration/UserAdministration", 
                new { statusMessage = $"The user {user.UserName} was successfully deleted." });
        }

    }
}
