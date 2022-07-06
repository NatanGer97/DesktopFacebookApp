using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
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

        public static List<FriendItem> GetFakeFriendsFriendItems()
        {
            string fileName = "DummyData.xml";
            List<FriendItem> fakeFriends = new List<FriendItem>();

            string path = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
                "FacebookWinFormsApp",
                fileName);

            if(File.Exists(fileName))
            {
                using(FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<FriendItem>));
                    fakeFriends = (List<FriendItem>)xmlSerializer.Deserialize(stream);
                }
            }

            return fakeFriends;
        }
    }
}