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
using UserManagementTestApp.Models;

namespace UserManagementTestApp.Areas.Identity.Pages.Account.Manage
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Introduction { get; set; }
        public SelectList Genders { get; set; }

        [BindProperty] public string UserGender { get; set; }
        //public string[] Genders = new[] { "Male", "Female", "Unspecified", "Don't want to say!" };

        [BindProperty] public InputModel Input { get; set; }

        public class InputModel
        {
            public string UserGender { get; set; }
            public string Introduction { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            var introduction = user.Introduction;
            UserGender = user.Gender;
            // ProfilePicture = user.ProfilePicture;

            Input = new InputModel
            {
                Introduction = introduction
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //Genders = new SelectList("Male", "Female", "Nonbinary", "Don't want to say");
            await LoadAsync(user);
            return Page();              
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

            var introduction = user.Introduction;
            if(Input.Introduction != introduction)
            {
                user.Introduction = Input.Introduction;
                await _userManager.UpdateAsync(user);
            }


            var gender = user.Gender;
            if (UserGender != gender)
            {
                user.Gender = UserGender;
                await _userManager.UpdateAsync(user);
            }
           
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
