using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Models
{
    /// <summary>
    /// Represents a user of the Travel Buddy app.
    /// Contains attributes related to user identity and preferences.
    /// </summary>
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }


        // one user can have many kind of trips
        // according to tripID we will retrieve all the acceccories, clothing,etc
        public List<int> TripIDs{ get; set; }
    }
}
