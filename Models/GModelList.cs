using Sharing_Free.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Models
{
    public class GModelList
    {
        private static GroupService gService = new GroupService();

        public List<GroupModel> GroupModelList = gService.GetAllModelGroups();
    }
}
