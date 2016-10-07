using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class Friend
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int hidden { get; set; }
    }

    public class FriendResponse
    {
        public int count { get; set; }
        public List<Friend> items { get; set; }
    }

    public class RootFriend
    {
        public FriendResponse response { get; set; }
    }
}
