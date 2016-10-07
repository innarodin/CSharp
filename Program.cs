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

        static void Main(string[] args)
        {
            //получить  пользователей группы
            string groupName = "csu_iit";
            var url = "https://api.vk.com/method/groups.getMembers?v=5.52&fields=1&group_id=" + groupName;
            RootGroupMembers users = JsonConvert.DeserializeObject<RootGroupMembers>(get(url));

            foreach (var user in users.response.items)
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
                    }                
            }

            Console.WriteLine("Sort by:\n1.Likes\n2.Reposts\n3.Comments");
            var tmp = Console.ReadLine();
           
            if(tmp == "1")
                posts.Sort(delegate(Post post1, Post post2)
                { 
                    return post1.likes.count.CompareTo(post2.likes.count); 
                });
            else if (tmp == "2")
                posts.Sort(delegate(Post post1, Post post2)
                {
                    return post1.reposts.count.CompareTo(post2.reposts.count);
                });
            else if (tmp == "3")
                posts.Sort(delegate(Post post1, Post post2)
                {
                    return post1.comments.count.CompareTo(post2.comments.count);
                });

            foreach (var i in posts)
            {
                Console.WriteLine(i.likes.count + " " + i.reposts.count + " " + i.comments.count + " " + i.text);
            }     

            Console.ReadLine();
 
        }
    }
}
