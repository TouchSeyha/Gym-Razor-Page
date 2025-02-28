using Microsoft.AspNetCore.Identity;
using System;

namespace Gym.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
