using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FacebookAppLogic
{
    public class FriendItem
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Birthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string FootballTeam { get; set; }

        public List<string> Languages { get; set; }

        public List<string> Locations { get; set; }

        public List<Post> Posts { get; set; }

        public string Religion { get; set; }

        public string Education { get; set; }

        public int NumberOfFriends { get; set; }
    }
}