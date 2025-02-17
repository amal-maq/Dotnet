using System;

namespace TripAPI.Models
{
    public class Trip
    {
        public int Id { get; set; } // primary key for the database 
        public string Destination { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public string Preferences { get; set; } 
    }
}
