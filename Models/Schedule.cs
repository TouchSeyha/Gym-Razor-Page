using System;
using System.Collections.Generic;

namespace Gym.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime SessionDateTime { get; set; } // Date and time of the training session
        public string SessionType { get; set; } = string.Empty;      // e.g., "Individual" or "Group"

        // Optional association with a coach (for individual training)
        public int? CoachId { get; set; }
        public required Coach Coach { get; set; } 

        // Optional association with a gym hall (for group training)
        public int? GymHallId { get; set; } 
        public required GymHall GymHall { get; set; }

        // For group training: list of customers signed up for the session
        public List<Customer> Attendees { get; set; } = new List<Customer>();

        // Optional: maximum number of attendees allowed (for group sessions)
        public int? Capacity { get; set; }
    }
}
