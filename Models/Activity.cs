using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Models
{

    /// <summary>
    /// The Activity class contains a list of recreational activities that a user wants to do.
    /// Each user can create multiple activities, including camping, swimming, and canoeing.
    /// This class helps in organizing and managing various outdoor and leisure activities for users.
    /// </summary>
    public class Activity
    {
        public string Camping { get; set; }

        public string Swimming { get; set; }

        public string Canoeing { get; set; }
    }
}
