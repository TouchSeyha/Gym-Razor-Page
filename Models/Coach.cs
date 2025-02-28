using System;

namespace Gym.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime Date { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required string Status { get; set; }
        public required string Specialization { get; set; }
        public required string WorkingHours { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
