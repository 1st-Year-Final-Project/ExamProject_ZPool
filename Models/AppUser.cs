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
        // The user Id is part of the base class IdentityUser and is named: Id
        // Email and others are also members of the base class
        // and do not require a concrete implementation

        public override int Id { get; set; } // this is overridden from the baseclass, pls don't change
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public byte[]? Avatar { get; set; } 
    }
}
