using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharing_Free.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Banned { get; set; } // how to set default: FALSE?
        public bool IsAdmin { get; set; }

        public User(int id, string username, string email, string password, bool banned, bool isAdmin)
        {
            Id = id;
            Email = email;
            Password = password;
            Username = username;
            Banned = banned;
            IsAdmin = isAdmin;
        }

        public User(int id, string username, string password, bool banned, bool isAdmin)
        {
            Id = id;
            Username = username;
            Password = password;
            Banned = banned;
            IsAdmin = isAdmin;
        }

        public User(string email, string password, string username, bool banned)
        {
            Email = email;
            Password = password;
            Username = username;
            Banned = banned;
        }

        public User(string username, string password, bool banned, bool isAdmin) : this(username, password)
        {
            Banned = banned;
            IsAdmin = isAdmin;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User()
        {
            
        }
    }
}