using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Services;
using Sharing_Free.Domain;

namespace Share_Free.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "IsAdmin")]
    public class AdminController : Controller
    {

        // Whole controller is under Policy

        [HttpGet("[action]")]
        public IEnumerable<User> AdminGetAllUser()
        {
            UserService uService = new UserService();

            List<User> allUsers = uService.GetAllUsers();

            return allUsers;
        }

        [HttpGet]
        public IActionResult AdminAccount()
        {
            bool isAdmin = Convert.ToBoolean(HttpContext.User.FindFirst("IsAdmin").Value.ToString());
            if (isAdmin == false)
            {
                Console.WriteLine("You are not authorized to access Admin page!");
                return RedirectToAction("Index", "Home");
            }
            return View();

        }


    }
}