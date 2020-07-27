using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharing_Free.Domain
{
    public class Post
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int CommentId { get; set; }

        public Post(int id, string username, string title, string description, DateTime date)
        {
            Id = id;
            Username = username;
            Title = title;
            Description = description;
            Date = date;
        }

        public Post()
        {
        }
    }
}