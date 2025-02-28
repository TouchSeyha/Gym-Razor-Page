using System;

namespace Gym.Models
{
    public class GymHall
    {
        public int Id { get; set; }
        public string HallName { get; set; } = string.Empty;
        public int Capacity { get; set; }     
        public string Location { get; set; } = string.Empty;
    }
}
