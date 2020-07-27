using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
//using System.Web.Http;
// using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Services;
using Sharing_Free.Domain;

namespace Share_Free.Controllers
{

    [Authorize]
    [Route("[controller]")]
    public class PostController : Controller
    {


        [HttpPost]
        [Route("[action]")]
        public Post CreatePost([FromForm] string title, [FromForm] string description)
        {
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            PostService pService = new PostService();

            Post post = pService.CreatePost(username, title, description);

            return post;
        }


        [HttpPost]
        [Route("[action]/{PostId}")]
        public void DeletePost(int PostId)
        {
            PostService pService = new PostService();


            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            bool isAdmin = Convert.ToBoolean(HttpContext.User.FindFirst("IsAdmin").Value.ToString());
            List<Post> userPosts = pService.GetAllPosts();
            foreach (var post in userPosts)
            {
                if ((username == post.Username || isAdmin == true) && PostId == post.Id)
                {
                    pService.DeletePost(PostId);
                    break;
                }
            }
        }

        [HttpPost("[action]")]
        public IActionResult ModifyPost([FromForm] int modifyPostId, [FromForm] string modifyPostTitle, [FromForm] string modifyPostDescription)
        {
            PostService pService = new PostService();

            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            bool isAdmin = Convert.ToBoolean(HttpContext.User.FindFirst("IsAdmin").Value.ToString());
            List<Post> userPosts = pService.GetAllPosts();
            foreach (var post in userPosts)
            {
                if ((username == post.Username || isAdmin == true) && modifyPostId == post.Id)
                {
                    pService.ModifyPost(modifyPostId, modifyPostTitle, modifyPostDescription);
                    break;
                }
            }
            return RedirectToAction("Index", "Home");

        }
    }
}