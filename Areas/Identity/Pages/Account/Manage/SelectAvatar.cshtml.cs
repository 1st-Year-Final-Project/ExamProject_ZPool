using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class SelectAvatarModel : PageModel
    {
        private readonly UserManager<AppUser> _manager;

        public SelectList AvatarList { get; set; }
        [BindProperty]public string UserAvatarName { get; set; }

        public SelectAvatarModel(UserManager<AppUser> manager)
        {
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);

            await LoadAsync(user);
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _manager.GetUserNameAsync(user);

            string avatarName = user.AvatarName;
            if (avatarName == "" || avatarName == null)
            {
                UserAvatarName = "default";
            }

            if (!string.IsNullOrWhiteSpace(avatarName))
            {
                UserAvatarName = user.AvatarName;
            }


        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _manager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_manager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }      

            var avatar = user.AvatarName;
            if (UserAvatarName != avatar)
            {
                user.AvatarName = UserAvatarName;
                await _manager.UpdateAsync(user);
            }

            
            return RedirectToPage();
        }

    }
}
