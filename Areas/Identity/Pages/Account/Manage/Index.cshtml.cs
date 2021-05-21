using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZPool.Models;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData] public string StatusMessage { get; set; }

       
        public string Username { get; set; }
        public string Email { get; set; }
        public SelectList GenderList { get; set; }

        [BindProperty] public string FirstName { get; set; }
        [BindProperty] public string LastName { get; set; }     
        [BindProperty] public string Introduction { get; set; }  // It is "About Me" 
        [BindProperty] public string UserAvatarName { get; set; }
        [BindProperty] public string UserGender { get; set; }

        [BindProperty] public InputModel Input { get; set; }

        public class InputModel
        {
            public string UserGender { get; set; }
            public string Introduction { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
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
            Email = user.Email;
            UserGender = user.Gender;
            Introduction = user.Introduction;
            UserAvatarName = user.AvatarName;
            
            if (string.IsNullOrEmpty(UserAvatarName))
            {
                UserAvatarName = "default.png";
            }
            else
            {
                UserAvatarName = user.AvatarName;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);        

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Gender = UserGender;
            user.Introduction = Introduction;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
