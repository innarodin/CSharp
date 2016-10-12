using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class Comments
    {
        public int count { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int owner_id { get; set; }
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
    }

    public class Wall
    {
        public int count { get; set; }
        public List<Post> items { get; set; }
    }

    public class RootWall
    {
        public Wall response { get; set; }
    }
}
