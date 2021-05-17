using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Services.Interface
{
    interface IUserService
    {
        public void DeleteUserProfile(AppUser user);
    }
}
