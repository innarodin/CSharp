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
        
        public int owner_id { get; set; }
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
    }
}
