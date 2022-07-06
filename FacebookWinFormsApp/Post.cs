using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    [XmlRoot(ElementName = "Post")]
    public class Post
    {
        [XmlElement(ElementName = "index")]
        public int Index { get; set; }

        [XmlElement(ElementName = "status_message")]
        public string StatusMessage { get; set; }

        [XmlElement(ElementName = "status_type")]
        public string StatusType { get; set; }

        [XmlElement(ElementName = "status_link")]
        public string StatusLink { get; set; }

        [XmlElement(ElementName = "status_published")]
        public DateTime StatusPublished { get; set; }

        [XmlElement(ElementName = "num_comments")]
        public int NumComments { get; set; }

        [XmlElement(ElementName = "num_shares")]
        public int NumShares { get; set; }

        [XmlElement(ElementName = "num_likes")]
        public int NumLikes { get; set; }

        public Post()
        {
        }
    }
}
