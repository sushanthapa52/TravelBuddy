using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Entities
{
    public class Checklist
    {
        public string TripName { get; set; }
        public DateTime TripDate { get; set; }
        public string ActivityType { get; set; }
        public List<bool> Accessories { get; set; }
        public List<bool> Electronics { get; set; }
        public List<bool> Clothes { get; set; }
    }
    public class Hiking
    {
        public List<string> Items { get; set; }

        public Hiking()
        {
            Items = new List<string>
        {
            "Hiking Boots",
            "Backpack",
            "Water Bottle",
            "Map",
            "Compass",
            "First Aid Kit"
        };
        }
    }


}
