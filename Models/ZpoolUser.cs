#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementTestApp.Models
{
    public class ZpoolUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDriver { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        
    }
}
