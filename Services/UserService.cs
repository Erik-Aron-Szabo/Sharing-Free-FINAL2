using Npgsql;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;

namespace Share_Free.Services
{
    public class UserService
    {

        // returns all the users from the database
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from \"user\"", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["user_id"]);
                        string username = reader["username"].ToString();
                        string email = reader["email"].ToString();
                        string password = reader["password"].ToString();
                        bool banned = Convert.ToBoolean(reader["banned"]);
                        bool isAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        allUsers.Add(new User(id, username, email, password, banned, isAdmin));
                    }
                }
            }
            return allUsers;
        }

        //Implement later
        //public void RegisterUser()
        //{
        //    using (var conn = new NpgsqlConnection(Program.ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand("insert into \"user\"(username, email, \"password\", banned)values(@username, @email, @password, @banned)", conn))
        //        {

        //        }
        //    }
        //}


    }
}
