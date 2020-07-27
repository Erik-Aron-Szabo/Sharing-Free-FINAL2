using Npgsql;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share_Free.Services
{
    public class PostService
    {


        // gets all post from a single user
        public List<Post> GetAllPostsFromUser(string username2)
        {
            List<Post> allPosts = new List<Post>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from post where(username = @username)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username2);
                    var id = 0;
                    string username = "";
                    string title = "";
                    string description = "";
                    DateTime date = DateTime.Now;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["post_id"]);
                        username = reader["username"].ToString();
                        title = reader["title"].ToString();
                        description = reader["description"].ToString();
                        date = Convert.ToDateTime(reader["date"]);
                        allPosts.Add(new Post(id, username, title, description, date));
                    }
                }
            }
            return allPosts;
        }



        // Returns List of Post
        public List<Post> GetAllPosts()
        {
            List<Post> allPosts = new List<Post>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from post", conn))
                {
                    var id = 0;
                    string username = "";
                    string title = "";
                    string description = "";
                    DateTime date = DateTime.Now;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["post_id"]);
                        username = reader["username"].ToString();
                        title = reader["title"].ToString();
                        description = reader["description"].ToString();
                        date = Convert.ToDateTime(reader["date"]);
                        allPosts.Add(new Post(id, username, title, description, date));
                    }
                }
            }
            return allPosts;
        }


        // Inserts new post into Database
        // MISSING string username, -
        // how to supply that? make your own CLAIM

        public Post Get1Post(string title2, string username2, string description2)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from post where username = @username and description = @description and title = @title", conn))
                {

                    cmd.Parameters.AddWithValue("username", username2);
                    cmd.Parameters.AddWithValue("description", description2);
                    cmd.Parameters.AddWithValue("title", title2);
                    int id = 0;
                    string username = "";
                    string title = "";
                    string description = "";
                    DateTime date = DateTime.Now;

                    var reader = cmd.ExecuteReader();

                    reader.Read();
                    id = Convert.ToInt32(reader["post_id"]);
                    username = reader["username"].ToString();
                    title = reader["title"].ToString();
                    description = reader["description"].ToString();
                    date = Convert.ToDateTime(reader["date"]);
                    var post = new Post(id, username, title, description, date);
                    return post;
                }
            }
        }

        public Post CreatePost(string username, string title, string description)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO post (username, title, description, date) VALUES (@username, @title, @description, @date) returning post_id", conn))
                {
                    DateTime date = DateTime.Now;

                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("date", date);

                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    Post newPost = new Post(reader.GetInt32(0), username, title, description, date);
                    return newPost;
                }
            }
        }



        // deletes post

        public void DeletePost(int id)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                // had to add "on delete cascade" to SQL Query at FK reference in comment
                using (var cmd = new NpgsqlCommand("DELETE FROM post WHERE post_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // modifies existing post
        public void ModifyPost(int id, string title, string description)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("update post set title = @title, description = @description where post_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("description", description);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
