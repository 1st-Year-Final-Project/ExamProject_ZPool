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
    public class DeleteUserModel : PageModel
    {
        
        private UserManager<AppUser> _userManager;
        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public DeleteUserModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task OnGetAsync()
        {
            LoggedInUser = await _userManager.GetUserAsync(User);

        }
        public async Task<IActionResult>  OnPostAsync()
        {

            await _userManager.DeleteAsync(LoggedInUser);
            

            return RedirectToPage("./SuccessfullyDeletedAccount");
        }
    }
}

