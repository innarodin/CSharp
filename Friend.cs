using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class Friend
    {
        private int id;
        private string first_name;
        private string last_name;
        private int hidden;

        public int GetId()
        {
            return this.id;
        }
        public string GetFirstName()
        {
            return this.first_name;
        }
        public string GetLastName()
        {
            return this.last_name;
        }
    }

    public class FriendResponse
    {
        private int count;
        private List<Friend> items;

        public int GetCount()
        {
            return this.count;
        }
        public List<Friend> GetItems()
        {
            return items;
        }
    }

    public class RootFriend
    {
        private FriendResponse response;

        public FriendResponse GetResponse()
        {
            return response;
        }
    }
}
