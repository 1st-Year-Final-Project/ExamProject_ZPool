using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserManagementTestApp.Areas.Identity.Pages.Account.Manage;
using UserManagementTestApp.Models;
using ZPool.Models;

namespace ZPool.Pages.TestFolder
{
    public class TestUserDataModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private AppDbContext _context;

        public TestUserDataModel(
            UserManager<AppUser> userManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public AppUser AppUser { get; set; }

        public TestCar Car { get; set; }


        public async Task<IActionResult> OnGet()
        {
            AppUser = await _userManager.GetUserAsync(User);
            if (AppUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            
            Car = _context.Cars.FirstOrDefault(c => c.UserId == AppUser.Id);

            return Page();
        }
    }
}
