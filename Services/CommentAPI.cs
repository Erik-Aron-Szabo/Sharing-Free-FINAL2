using Microsoft.AspNetCore.Mvc;
using Share_Free.Domain;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Services
{
    [ApiController]
    [Route("CommentAPI")]
    public class CommentAPI
    {

        [HttpGet("[action]")]
        public IEnumerable<Comment> GetAllComments()
        {
            CommentService cService = new CommentService();
            List<Comment> allComments = cService.GetAllComments();

            return allComments;
        }


    }
}
