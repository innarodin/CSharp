using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class VkClient
    {
        private VkApi vk = new VkApi();
        public List<User> GetGraph()
        {
            //получить граф для пользователей группы
            var groupName = "csu_iit";

            List<User> graphUsers = new List<User>();

            foreach (var i in vk.GetGroupMembers(groupName))
            {
                User usr = new User(i.id, i.first_name, i.last_name);
                usr.SetFriends(vk.GetFriends(i.id));

                graphUsers.Add(usr);

                //Console.WriteLine(user.id + " " + user.first_name + " " + user.last_name);
            }

            foreach (var i in graphUsers)
            {
                Console.WriteLine(i.GetId() + " " + i.GetFirstName() + " " + i.GetLastName());
            }

            return graphUsers;
        }

        public List<Post> GetPosts()
        {
            var graphUsers = GetGraph();
            Console.WriteLine("Select user by id: ");
            var idUser = Console.ReadLine();

            //получить записи стены друзей пользователя
            List<Post> posts = vk.GetPosts(idUser, graphUsers);

            Console.WriteLine("Sort by:\n1.Likes\n2.Reposts\n3.Comments");
            var tmp = Console.ReadLine();

            Sorter sorter = new Sorter();
            if (tmp == "1") sorter.SortByLikes(posts);
            else if (tmp == "2") sorter.SortByReposts(posts);
            else if (tmp == "3") sorter.SortByComments(posts);

            foreach (var i in posts)
            {
                Console.WriteLine(i.likes.count + " " + i.reposts.count + " " + i.comments.count + " " + i.text);
            }

            Console.ReadLine();
            return posts;
        }

    }
}
