using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class Sorter
    {
        public List<Post> SortByLikes(List<Post> posts)
        {
            posts.Sort((post1, post2) => post1.likes.count.CompareTo(post2.likes.count));
            return posts;
        }

        public List<Post> SortByReposts(List<Post> posts)
        {
            posts.Sort((post1, post2) => post1.reposts.count.CompareTo(post2.reposts.count));
            return posts;
        }

        public List<Post> SortByComments(List<Post> posts)
        {
            posts.Sort((post1, post2) => post1.comments.count.CompareTo(post2.comments.count));
            return posts;
        }
    }
}
