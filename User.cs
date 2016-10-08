using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class User
    {
        private Member user;
        private List<Friend> friends;

        public void SetUser(Member item)
        {
            user = item;
        }
        public Member GetUser()
        {
            return user;
        }
        public void SetFriends(List<Friend> items)
        {
            friends = items;
        }
        public List<Friend> GetFriends()
        {
            return friends;
        }
    }
}
