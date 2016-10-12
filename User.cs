using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp
{
    class User
    {
        private string id;
        private string firstname;
        private string lastname;
        private List<VKMember> friends;

        public User(string uid, string name, string lname)
        {
            SetId(uid);
            SetFirstName(name);
            SetLastName(lname);
        }
        public User()
        {
           
        }

        public void SetId(string uid)
        {
            this.id = uid;
        }
        public void SetFirstName(string name)
        {
            firstname = name;
        }
        public void SetLastName(string name)
        {
            this.lastname = name;
        }

        public string GetId()
        {
            return id;
        }
        public string GetFirstName()
        {
            return firstname;
        }
        public string GetLastName()
        {
            return lastname;
        }

        public void SetFriends(List<VKMember> items)
        {
            friends = items;
        }
        public List<VKMember> GetFriends()
        {
            return friends;
        }
    }
}
