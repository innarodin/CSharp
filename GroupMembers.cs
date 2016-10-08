using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class Member
    {
        private int id;
        private string first_name;
        private string last_name;
        private int hidden;
        private string deactivated;       
        
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

    public class GroupMembers
    {
        private int count;
        private List<Member> items;

        public int GetCount()
        {
            return this.count;
        }
        public List<Member> GetItems()
        {
            return items;
        }
    }

    public class RootGroupMembers
    {
        private GroupMembers response;
        public GroupMembers GetResponse()
        {
            return response;
        }
    }
}
