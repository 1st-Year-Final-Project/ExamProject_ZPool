using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class ReadOnlyProfilePageModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public ReadOnlyProfilePageModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Introduction { get; set; }
        public string UserAvatarName { get; set; }
        public string UserGender { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //var user = await _userManager.GetUserAsync(User);

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserGender = user.Gender;
            Introduction = user.Introduction;

            string avatarName = user.AvatarName;
            if (avatarName == "" || avatarName == null)
            {
                UserAvatarName = "default.png";
            }
            else
            {
                UserAvatarName = avatarName;
            } 
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var gender = user.Gender;
            if (UserGender != gender)
            {
                user.Gender = UserGender;
                await _userManager.UpdateAsync(user);
            }

            var avatar = user.AvatarName;
            if (UserAvatarName != avatar)
            {
                user.AvatarName = UserAvatarName;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToPage();
        }
    }
}

