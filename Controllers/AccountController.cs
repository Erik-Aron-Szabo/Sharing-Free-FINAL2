using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Services;
using Sharing_Free.Domain;

namespace Share_Free.Controllers
{
    public class AccountController : Controller
    {

        
        [HttpGet]
        [Authorize]
        public IActionResult MyAccount()
        {
            //PostService pService = new PostService();
            //string username = HttpContext.User.FindFirst("Username").Value.ToString();
            //List<Post> userPosts = pService.GetAllPostsFromUser(username);

            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm(Name ="username")] string username, [FromForm(Name ="password")] string password)
        {
            UserService uService = new UserService();
            List<User> allUsers = uService.GetAllUsers();
            User currentUser = new User(username, password);


            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }

            foreach (var user in allUsers)
            {
                
                // identifies user
                if (user.Username == currentUser.Username && user.Password == currentUser.Password)
                {
                    User identifiedUser = new User(user.Id, username, password, user.Banned, user.IsAdmin);

                    // checks if identified user is Admin
                    if (identifiedUser.IsAdmin == true)
                    {
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                            {
                                new Claim("Username", identifiedUser.Username),
                                new Claim("Id", identifiedUser.Id.ToString()),
                                new Claim("IsAdmin", identifiedUser.IsAdmin.ToString())
                            }, CookieAuthenticationDefaults.AuthenticationScheme)),
                            new AuthenticationProperties());

                        return RedirectToAction("AdminAccount", "Admin");
                    }
                    else
                    {
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                            {
                                new Claim("Username", identifiedUser.Username),
                                new Claim("IsAdmin", identifiedUser.IsAdmin.ToString()),
                                new Claim("Id", identifiedUser.Id.ToString())
                            }, CookieAuthenticationDefaults.AuthenticationScheme)),
                            new AuthenticationProperties());


                        return RedirectToAction("Index", "Home");
                    }
                    break;
                }
            }

            return RedirectToAction("Login");


        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}