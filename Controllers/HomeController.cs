using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Models;
using Share_Free.Services;

namespace Share_Free.Controllers
{
    public class HomeController : Controller
    {


        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyGroups()
        {
            ViewData["Message"] = "You can see the the groups you are in, here.";

            return View();
        }

        public IActionResult MyAccount()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        // Lets user create new Post
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromForm(Name = "title")] string title, [FromForm(Name = "description")]string description)
        {
            // username missing
            PostService pService = new PostService();
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            pService.CreatePost(username, title, description);

            return RedirectToAction("Index", "Home");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
