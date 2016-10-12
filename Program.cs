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

            foreach (var i in vk.GetGroupMembers(groupName))
            {
                User usr = new User(i.id,i.first_name,i.last_name);
                usr.SetFriends(vk.GetFriends(i.id));

                graphUsers.Add(usr);

                //Console.WriteLine(user.id + " " + user.first_name + " " + user.last_name);
            }

            foreach (var i in graphUsers)
            {
                Console.WriteLine(i.GetId() + " " + i.GetFirstName() + " " + i.GetLastName());
            }    

            Console.WriteLine("Select user by id: ");
            var idUser = Console.ReadLine();

            //получить записи стены друзей пользователя
            List<Post> posts = vk.GetPosts(idUser, graphUsers);
          
            Console.WriteLine("Sort by:\n1.Likes\n2.Reposts\n3.Comments");
            var tmp = Console.ReadLine();

            Sorter sorter = new Sorter();
            if (tmp == "1") sorter.SortByLikes(ref posts);
            else if (tmp == "2") sorter.SortByReposts(ref posts);
            else if (tmp == "3") sorter.SortByComments(ref posts);

            foreach (var i in posts)
            {
                Console.WriteLine(i.likes.count + " " + i.reposts.count + " " + i.comments.count + " " + i.text);
            }     

            Console.ReadLine();
 
        }
    }
}
