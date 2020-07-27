using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group()
        {

        }

        public Group(string name)
        {
            Name = name;
        }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
