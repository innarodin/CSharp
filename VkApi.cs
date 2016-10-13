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
        private string Get(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            var response = (HttpWebResponse) request.GetResponse();
            var responseJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseJson;
        }

        public List<VKMember> GetGroupMembers(string groupName)
        {
            var url = "https://api.vk.com/method/groups.getMembers?v=5.52&fields=1&group_id=" + groupName;
            RootGroupMembers users = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            return users.response.items;
        }

        public List<User> GetFriends(string idUser)
        {
            var url = "https://api.vk.com/method/friends.get?v=5.52&fields=id,first_name,last_name&user_id=" + idUser;
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
            List<Post> posts = new List<Post>();
            User user = graphUsers.Find(x => x.GetId() == uid);
            
            foreach (var friend in user.GetFriends())
            {
                var url = "https://api.vk.com/method/wall.get?v=5.52&owner_id=" + friend.GetId();
                RootWall wall = JsonConvert.DeserializeObject<RootWall>(Get(url));

                if (wall.response != null)
                    posts.AddRange(wall.response.items);
            }
            return posts;
        }
    }
}
