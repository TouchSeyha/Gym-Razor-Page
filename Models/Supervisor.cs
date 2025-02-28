using System;

namespace Gym.Models
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;  // e.g., Supervisor, Senior Supervisor
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Again, ensure secure handling in production
    }
}
