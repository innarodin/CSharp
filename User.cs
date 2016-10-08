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
        private List<Member> friends;

        public void SetUser(Member item)
        {
            user = item;
        }
        public Member GetUser()
        {
            return user;
        }
        public void SetFriends(List<Member> items)
        {
            friends = items;
        }
        public List<Member> GetFriends()
        {
            return friends;
        }
    }
}
