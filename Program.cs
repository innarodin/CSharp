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
        static void Main(string[] args)
        {
            //получить граф для пользователей группы
            VkApi vk = new VkApi();
            var groupName = "csu_iit";

            List<User> graphUsers = new List<User>();
            foreach (var item in vk.GetGroupMembers(groupName).GetResponse().GetItems())
            {
                User usr = new User();
                usr.SetUser(item);
                usr.SetFriends(vk.GetFriends(item.GetId()).GetResponse().GetItems());

                graphUsers.Add(usr);

                //Console.WriteLine(user.id + " " + user.first_name + " " + user.last_name);
            }

            Console.WriteLine("Select user by id: ");
            var idUser = Console.ReadLine();

            //получить записи стены друзей пользователя
        /*    List<Post> posts = new List<Post>();
            foreach (var friend in friends.response.items)
            {
                url = "https://api.vk.com/method/wall.get?v=5.52&owner_id=" + friend.id;
                RootWall wall = JsonConvert.DeserializeObject<RootWall>(Get(url));

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
 */
        }
    }
}
