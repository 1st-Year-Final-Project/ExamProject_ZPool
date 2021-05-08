using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using static System.Net.Mime.MediaTypeNames;

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

        //public enum Gender
        //{
        //    Male,
        //    Female,
        //    Nonbinary,
        //    Guess // if you don't want to say 
        //}

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public BitArray ProfilePicture { get; set; }
        public string Introduction { get; set; }
        [BindProperty] public string SelectGender { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty] 
        public InputModel Input { get; set; }


        public class InputModel
        {
            //[Phone]
            //[Display(Name = "Phone number")]
            //public string PhoneNumber { get; set; }

            //public BitArray ProfilePicture { get; set; }
            public string Introduction { get; set; }
            public string UserGender { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            var gender = user.UserGender;
            var introduction = user.Introduction;
            //var picture = user.ProfilePicture;

            /// suggest: add an attribute of profilePicture in AppUser.cs
            /// ProfilePicture = user.ProfilePicture;

            Input = new InputModel
            {
                Introduction = user.Introduction,
                UserGender = user.UserGender,
                //ProfilePicture = picture
            };


            //Input = new InputModel
            //{
            //    PhoneNumber = phoneNumber
            //};
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
            user.Introduction = Input.Introduction;

            var gender = user.UserGender;
            user.UserGender = SelectGender; 

            //var picture = user.ProfilePicture;
            //user.ProfilePicture = Input.ProfilePicture;
            
            await _userManager.UpdateAsync(user);


            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
