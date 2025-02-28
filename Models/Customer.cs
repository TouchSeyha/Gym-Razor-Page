using System;

namespace Gym.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
