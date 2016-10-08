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

        public RootGroupMembers GetGroupMembers(string groupName)
        {
            var url = "https://api.vk.com/method/groups.getMembers?v=5.52&fields=1&group_id=" + groupName;
            RootGroupMembers users = JsonConvert.DeserializeObject<RootGroupMembers>(Get(url));
            return users;
        }

        public RootFriend GetFriends(int idUser)
        {
            var url = "https://api.vk.com/method/friends.get?v=5.52&fields=id,first_name,last_name&user_id=" + idUser;
            RootFriend friends = JsonConvert.DeserializeObject<RootFriend>(Get(url));
            return friends;
        }
    }
}
