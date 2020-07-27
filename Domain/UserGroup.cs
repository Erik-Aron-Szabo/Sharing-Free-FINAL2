using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Domain
{
    public class UserGroup
    {
        public string Username { get; set; }
        public string GroupName { get; set; }

        public UserGroup(string username, string groupName)
        {
            Username = username;
            GroupName = groupName;
        }
    }
}
