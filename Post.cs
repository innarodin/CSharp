using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class Post
    {
        private int id;
        public int Id {
            get { return id; }
            set { id = value; } 
        }

        private int fromId;
        public int FromId
        {
            get { return fromId; }
            set { fromId = value; } 
        }
        
        public int ownerId { get; set; }
        public int date { get; set; }
        public string postType { get; set; }
        public string text { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
    }
}
