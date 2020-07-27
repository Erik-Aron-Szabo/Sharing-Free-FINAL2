using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share_Free.Domain;
using Share_Free.Models;
using Sharing_Free.Services;

namespace Share_Free.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class GroupController : Controller
    {

        [HttpPost("[action]")]
        public IActionResult LeaveGroup([FromForm] string groupIdLeave, [FromForm] string userIdLeave)
        {
            GroupService gService = new GroupService();
            int groupIdLeave2 = Convert.ToInt32(groupIdLeave);
            int userIdLeave2 = Convert.ToInt32(userIdLeave);
            gService.LeaveGroup(userIdLeave2, groupIdLeave2);

            return RedirectToAction("MyGroups", "Group");

        }


        // rework needed
        [HttpPost("[action]")]
        public IActionResult JoinGroup([FromForm] string groupId, [FromForm] string userId)
        {
            GroupService gService = new GroupService();
            int groupId2 = Convert.ToInt32(groupId);
            int userId2 = Convert.ToInt32(userId);
            gService.JoinGroup(userId2, groupId2);

            return RedirectToAction("MyGroups", "Group");
        }

        [HttpGet]
        public IActionResult MyGroups()
        {
            GroupService gService = new GroupService();
            List<GroupModel> myGroups = new List<GroupModel>();
            int userId = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            myGroups = gService.UserModelGroups(userId, username);

            return View();
        }

        [HttpGet("[action]")] 
        public string MyUsername()
        {
            string username = HttpContext.User.FindFirst("Username").Value.ToString();
            return username;
        }



    }
}