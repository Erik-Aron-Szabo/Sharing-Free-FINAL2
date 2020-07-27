using Npgsql;
using Share_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Services
{
    public class CommentService
    {

        // gets all comments from a user
        public List<Comment> GetAllCommentsFromUser(string username2)
        {
            List<Comment> userComments = new List<Comment>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from \"comment\" where username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("username", username2);

                    int id = 0;
                    string username = "";
                    string message = "";
                    int post_id = 0;
                    DateTime date = DateTime.Now;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["comment_id"]);
                        username = reader["username"].ToString();
                        message = reader["message"].ToString();
                        date = Convert.ToDateTime(reader["date"]);
                        post_id = Convert.ToInt32(reader["post_id"]);
                        userComments.Add(new Comment(id, username, message, date, post_id));
                    }

                }
            }
            return userComments;
        }


        public List<Comment> GetAllComments()
        {
            List<Comment> allComments = new List<Comment>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from \"comment\"", conn))
                {
                    int id = 0;
                    string username = "";
                    string message = "";
                    int post_id = 0;
                    DateTime date = DateTime.Now;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["comment_id"]);
                        username = reader["username"].ToString();
                        message = reader["message"].ToString();
                        date = Convert.ToDateTime(reader["date"]);
                        post_id = Convert.ToInt32(reader["post_id"]);
                        allComments.Add(new Comment(id, username, message, date, post_id));
                    }

                }
            }
            return allComments;
        }

        // adds comment to DataBase
        public void CreateComment(string username, string message, int postId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("insert into \"comment\"(username, \"message\", date, post_id) values(@username, @message, @date, @postId)",conn))
                {
                    DateTime date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@postId", postId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // deletes comment based on id
        public void DeleteComment(int commentId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("delete from \"comment\" where comment_Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", commentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Modifies existing comment based on id
        public void ModifyComment(string message, int id)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("update \"comment\" set message = @message where comment_id = @id ", conn))
                {
                    cmd.Parameters.AddWithValue("message", message);
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
