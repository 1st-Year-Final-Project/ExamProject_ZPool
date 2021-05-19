using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;

namespace ZPool.Pages.Administration
{
    [Authorize(Roles = "Admin")]
    public class UserAdministrationModel : PageModel
    {
        private UserManager<AppUser> _userManager;

        public UserAdministrationModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<AppUser> Users { get; set; }

        public string StatusMessage { get; set; }

        public void OnGet(string statusMessage)
        {
            StatusMessage = statusMessage;
            Users = _userManager.Users;
        }


    }
}
