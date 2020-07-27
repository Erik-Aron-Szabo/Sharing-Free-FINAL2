using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Services
{
    [ApiController]
    [Route("PostAPI")]
    public class PostAPI
    {



        [HttpGet("[action]")]
        public IEnumerable<Post> GetAllPost()
        {
            PostService pService = new PostService();
            List<Post> allPosts = pService.GetAllPosts();

            return allPosts;
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public void DeletePost(int PostId)
        {
            PostService pService = new PostService();
            List<Post> userPosts = pService.GetAllPosts();
            pService.DeletePost(PostId);
        }
    }
}
