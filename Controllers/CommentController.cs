using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Domain;
using Share_Free.Services;

namespace Share_Free.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public void ModifyComment([FromForm] string message, [FromForm] int commentId)
        {
            CommentService cService = new CommentService();
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            bool isAdmin = Convert.ToBoolean(HttpContext.User.FindFirst("IsAdmin").Value.ToString());
            List<Comment> userComments = cService.GetAllComments();
            foreach (var comment in userComments)
            {
                if ((username == comment.Username || isAdmin == true) && commentId == comment.Id )
                {
                    cService.ModifyComment(message, commentId);
                }
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateComment([FromForm(Name = "message")] string message, [FromForm(Name = "postId")] int postId)
        {
            // username missing
            CommentService cService = new CommentService();
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            cService.CreateComment(username, message, postId);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost("[action]")]
        public void DeleteComment([FromForm] int commentId)
        {
            CommentService cService = new CommentService();
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            bool isAdmin = Convert.ToBoolean(HttpContext.User.FindFirst("IsAdmin").Value.ToString());
            List<Comment> allComments = cService.GetAllComments();
            foreach (var comment in allComments)
            {
                if ((username == comment.Username || isAdmin == true) && commentId == comment.Id)
                {
                    cService.DeleteComment(commentId);
                }
            }
        }


    }
}