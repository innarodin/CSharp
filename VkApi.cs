using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplicationCSharp
{
    class VkApi
    {
        private string mainUrl = "https://api.vk.com/method/";
        private string Get(string url)
        {
            string request; 
            using (WebClient client = new WebClient()) 
            { 
                client.Encoding = Encoding.UTF8;
                request = client.DownloadString(mainUrl + url + "&v=5.52"); 
            }
            return request;
        }

        public List<VKMember> GetGroupMembers(string groupName)
        {
            var url = "groups.getMembers?fields=1&group_id=" + groupName;
            RootGroupMembers users = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            return users.response.items;
        }

        public List<User> GetFriends(string idUser)
        {
           var url = "friends.get?fields=id,first_name,last_name&user_id=" + idUser;
           RootGroupMembers friends = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            if (friends.response == null)
                return null;
            List<User> users = new List<User>();
            foreach (var i in friends.response.items)
            {
                User user = new User(i.id, i.first_name, i.last_name);
                users.Add(user);
            }
            return users;
        }

        public List<Post> GetPosts(string uid, List<User> graphUsers)
        {
            var posts = new List<Post>();
            User user = graphUsers.Find(x => x.GetId() == uid);
            var converter = new Converter();

            foreach (var friend in user.GetFriends())
            {
                var url = "wall.get?owner_id=" + friend.GetId();
                RootWall wall = JsonConvert.DeserializeObject<RootWall>(Get(url));

                if (wall.response != null)
                {
                    foreach (var item in wall.response.items)
                    {
                        Post post = converter.FromWallItemToPost(item);
                        posts.Add(post);
                    }
                }
                  //  posts.AddRange(converter.FromWallItemToPost(wall.response.items));
            }
            return posts;
        }
    }
}
