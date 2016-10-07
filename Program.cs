using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ConsoleApplicationCSharp
{
    class Program
    {
        static string get(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var responseJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseJson;
        }

         static string post(string url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseJson;
        }
       

        static void Main(string[] args)
        {
            //получить id пользователей группы
            string groupName = "csu_iit";
            var url = "https://api.vk.com/method/groups.getMembers?v=5.52&group_id=" + groupName;
            RootGroupMembers ids = JsonConvert.DeserializeObject<RootGroupMembers>(get(url));

            //получить имена пользователей
            url = "https://api.vk.com/method/users.get";
            var postData = "v=5.52&user_ids=";
            foreach (var item in ids.response.items)
            {
                postData += item + ",";
            }
            RootUser users = JsonConvert.DeserializeObject<RootUser>(post(url, postData));

            foreach (var user in users.response)
            {
                Console.WriteLine(user.id + " " + user.first_name + " " + user.last_name);
            }

            Console.WriteLine("Select user by id: ");
            var idUser = Console.ReadLine();

            //получить друзей пользователя
            url = "https://api.vk.com/method/friends.get?v=5.52&fields=id,first_name,last_name&user_id=" + idUser;
            RootFriend friends = JsonConvert.DeserializeObject<RootFriend>(get(url));

            //получить записи стены друзей пользователя
            List<Post> posts = new List<Post>();
            foreach (var friend in friends.response.items)
            {
                url = "https://api.vk.com/method/wall.get?v=5.52&owner_id=" + friend.id;
                RootWall wall = JsonConvert.DeserializeObject<RootWall>(get(url));

                if(wall.response != null)
                    foreach (var item in wall.response.items)
                    {
                        posts.Add(item); 
                        Console.WriteLine(item.likes.count + " " + item.text);
                    }                
            }
            //Sort();
    

            Console.ReadLine();
 
        }
    }
}
