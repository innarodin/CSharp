using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class Converter
    {
        public Post FromWallItemToPost(WallItem wallItem)
        {
            var post = new Post
            {
                Id = wallItem.id,
                FromId = wallItem.from_id,
                date = wallItem.date,
                postType = wallItem.post_type,
                text = wallItem.text,
                comments = wallItem.comments,
                likes = wallItem.likes,
                reposts = wallItem.reposts
            };

            return post;
        }
    }
}

