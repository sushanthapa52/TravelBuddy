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
                "First Aid Kit",
                "Sunscreen",
                "Sunglasses",
                "Trekking Poles",
                "Energy Bars"
            };
        }
    }

    public class Camping
    {
        public List<string> Items { get; set; }

        public Camping()
        {
            Items = new List<string>
            {
                "Tent",
                "Sleeping Bag",
                "Camping Stove",
                "Flashlight",
                "Multi-tool",
                "Camping Chair",
                "Cooler",
                "Portable Grill",
                "Lantern",
                "Camping Hammock"
            };
        }
    }

    public class Beach
    {
        public List<string> Items { get; set; }

        public Beach()
        {
            Items = new List<string>
            {
                "Swimsuit",
                "Beach Towel",
                "Sunscreen",
                "Beach Umbrella",
                "Cooler",
                "Sunglasses",
                "Flip Flops",
                "Beach Chair",
                "Snorkeling Gear",
                "Beach Ball"
            };
        }
    }

    public class Skiing
    {
        public List<string> Items { get; set; }

        public Skiing()
        {
            Items = new List<string>
            {
                "Ski Jacket",
                "Ski Pants",
                "Ski Boots",
                "Skis or Snowboard",
                "Ski Goggles",
                "Helmet",
                "Gloves",
                "Neck Warmer",
                "Thermal Underwear",
                "Ski Pass"
            };
        }
    }

    public class RoadTrip
    {
        public List<string> Items { get; set; }

        public RoadTrip()
        {
            Items = new List<string>
            {
                "Car Charger",
                "GPS",
                "Road Maps",
                "First Aid Kit",
                "Cooler",
                "Snacks",
                "Sunglasses",
                "Travel Pillow",
                "Blanket",
                "Travel Games"
            };
        }
    }

    public class Cycling
    {
        public List<string> Items { get; set; }

        public Cycling()
        {
            Items = new List<string>
            {
                "Bicycle",
                "Helmet",
                "Water Bottle",
                "Cycling Gloves",
                "Sunglasses",
                "Bike Repair Kit",
                "Cycling Shoes",
                "Energy Bars",
                "Bike Lock",
                "Reflective Vest"
            };
        }
    }



}
