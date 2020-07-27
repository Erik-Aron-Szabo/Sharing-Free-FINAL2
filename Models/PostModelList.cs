using Share_Free.Services;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Models
{
    public class PostModelList
    {
        PostService pService = new PostService();
        PostModelList pmList = new PostModelList();
        public List<Post> Posts { get; set; }
    }
}
