using Microsoft.AspNetCore.Http;
using Sharing_Free.Domain;
using Sharing_Free.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GroupModel()
        {
        }
    }
}
