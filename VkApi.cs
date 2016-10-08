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

        public List<Member> GetGroupMembers(string groupName)
        {
            var url = "https://api.vk.com/method/groups.getMembers?v=5.52&fields=1&group_id=" + groupName;
            RootGroupMembers users = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            return users.response.items;
        }

        public List<Member> GetFriends(int idUser)
        {
            var url = "https://api.vk.com/method/friends.get?v=5.52&fields=id,first_name,last_name&user_id=" + idUser;
            RootGroupMembers friends = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            if (friends.response == null)
                return null;
            return friends.response.items;
        }

        public RootWall GetPosts(string idUser, List<User> graphUsers)
        {
            List<Post> posts = new List<Post>();
            User user = new User();

            
           /* foreach (var friend in )
            {
                url = "https://api.vk.com/method/wall.get?v=5.52&owner_id=" + friend.id;
                RootWall wall = JsonConvert.DeserializeObject<RootWall>(Get(url));

                if (wall.response != null)
                    foreach (var item in wall.response.items)
                    {
                        posts.Add(item);
                    }
            }*/
            return null;
        }
    }
}
