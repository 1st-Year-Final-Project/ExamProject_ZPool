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
        [BindProperty] public byte[] UserAvatar { get; set; }

        public SelectAvatarModel(UserManager<AppUser> manager)
        {
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);

            
        }

    }
}
