#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ZPool.Models;

namespace UserManagementTestApp.Models
{
    public class AppUser : IdentityUser<int>
    {
        // the user Id is part of the base class IdentityUser and is named: Id
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }

    }
}
