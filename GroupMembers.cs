using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    public class GroupMembers
    {
        public int count { get; set; }
        public List<int> items { get; set; }
    }

    public class RootGroupMembers
    {
       public GroupMembers response { get; set; }
    }
}
