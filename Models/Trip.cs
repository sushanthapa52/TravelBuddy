using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Models
{

    /// <summary>
    /// The Trip class represents a trip planned by the user.
    /// It includes a unique TripID, the name of the trip, and the category of the trip.
    /// This class helps in organizing and categorizing various trips for better management.
    /// </summary>
    public class Trip
    {
        public int TripID { get; set; }
        public string TripName { get; set; }

        public string TripCategory { get; set; }

    }
}
