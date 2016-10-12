using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class VKMember
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int hidden { get; set; }
        public string deactivated { get; set; }   
        
    }

    public class GroupMembers
    {
        public int count { get; set; }
        public List<VKMember> items { get; set; }
    }

    public class RootGroupMembers
    {
        public GroupMembers response { get; set; }
       
    }
}
