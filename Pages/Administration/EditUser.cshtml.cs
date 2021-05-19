using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using VisioForge.Shared.MediaFoundation;

namespace ZPool.Pages.Administration
{
    public class EditUserModel : PageModel
    {
        private UserManager<AppUser> _userManager;

        public EditUserModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        [BindProperty]
        public int UserId { get; set; }
        
        [BindProperty]
        [Required]
        public InputModel Input { get; set; } = new InputModel();
        public class InputModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public List<IdentityError> ErrorList { get; set; } = new List<IdentityError>();

        public string StatusMessage { get; set; }

        public async Task OnGetAsync(int userId, string statusMessage)
        {
            StatusMessage = statusMessage;
            AppUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserId = userId;
            Input.FirstName = user.FirstName;
            Input.LastName = user.LastName;
            Input.UserName = user.UserName;
            Input.Email = user.Email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            AppUser user = await _userManager.FindByIdAsync(UserId.ToString());
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.UserName = Input.UserName;
            user.Email = Input.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                ErrorList = result.Errors.ToList();
                return Page();
            }

            return RedirectToPage($"/Administration/EditUser", new {userId = user.Id, statusMessage = "The user data was updated" });
        }
    }
}
