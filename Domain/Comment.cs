using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int Post_Id { get; set; }

        public Comment(int id, string username, string message, DateTime date, int post_Id)
        {
            Id = id;
            Username = username;
            Message = message;
            Date = date;
            Post_Id = post_Id;
        }


        public Comment()
        {

        }
    }
}
