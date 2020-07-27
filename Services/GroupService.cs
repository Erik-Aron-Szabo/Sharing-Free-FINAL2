using Npgsql;
using Share_Free;
using Share_Free.Domain;
using Share_Free.Models;
using Sharing_Free.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharing_Free.Services
{
    public class GroupService : IGroupService
    {

        // leave group - tested in SQL, works 
        // how to get groupId?
        public void LeaveGroup(int userId, int groupId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("delete from user_group where user_group.user_id = @userId and user_group.group_id = @groupId", conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("groupId", groupId);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // rework
        // user joins group
        public void JoinGroup(int userId, int groupId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd = new NpgsqlCommand(
                        "insert into user_group(user_id, group_id) values(@userId, @groupId)"
                    , conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("groupId", groupId);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // returns the groups the user is in
        //public List<UserGroup> UserGroups(int userId, string username)
        //{
        //    List<UserGroup> userGroups = new List<UserGroup>();
        //    using (var conn = new NpgsqlConnection(Program.ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand("select distinct u.username, \"group\".group_name from \"group\" inner join user_group as ug on ug.group_id = \"group\".group_id inner join \"user\" as u on ug.user_id = @userId where u.username = @username order by \"group\".group_name,  u.username asc; ", conn))
        //        {
        //            cmd.Parameters.AddWithValue("userId", userId);
        //            cmd.Parameters.AddWithValue("username", username);
        //            string groupName = "";
        //            string userName = "";



        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                try
        //                {
        //                    // name it as you see it PgAdmin
        //                    groupName = reader["group_name"].ToString();
        //                    userName = reader["username"].ToString();
        //                    userGroups.Add(new UserGroup(userName, groupName));
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine(ex.Message);
        //                }
        //            }
        //        }
        //    }
        //    return userGroups;
        //}


        // function as above, using GROUP instead of UserGroup
        public List<Group> UserGroups(int userId, string username)
        {
            List<Group> userGroups = new List<Group>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select distinct u.username, \"group\".group_name, \"group\".group_id from \"group\" inner join user_group as ug on ug.group_id = \"group\".group_id inner join \"user\" as u on ug.user_id = @userId where u.username = @username order by \"group\".group_name,  u.username asc; ", conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("userId", userId);
                    string groupName = "";
                    int groupId = 0;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            // name it as you see it PgAdmin
                            groupName = reader["group_name"].ToString();
                            groupId = Convert.ToInt32(reader["group_id"]);
                            userGroups.Add(new Group(groupId, groupName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            return userGroups;
        }

        // modells
        public List<GroupModel> UserModelGroups(int userId, string username)
        {
            List<GroupModel> userGroups = new List<GroupModel>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select distinct u.username, \"group\".group_name, \"group\".group_id from \"group\" inner join user_group as ug on ug.group_id = \"group\".group_id inner join \"user\" as u on ug.user_id = @userId where u.username = @username order by \"group\".group_name,  u.username asc; ", conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("userId", userId);
                    string groupName = "";
                    int groupId = 0;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            // name it as you see it PgAdmin
                            groupName = reader["group_name"].ToString();
                            groupId = Convert.ToInt32(reader["group_id"]);
                            userGroups.Add(new GroupModel(groupId, groupName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            return userGroups;
        }

        // return all groups
        public List<Group> GetAllGroups()
        {
            List<Group> allGroups = new List<Group>();

            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select distinct * from \"group\" order by group_name asc", conn))
                {

                    int id = 0;
                    string name = "";
                    List<string> usernames = new List<string>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["group_id"]);
                        name = reader["group_name"].ToString();
                        allGroups.Add(new Group(id, name));
                    }
                }
            }
            return allGroups;
        }


        // modells
        public List<GroupModel> GetAllModelGroups()
        {
            List<GroupModel> allGroups = new List<GroupModel>();

            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select distinct * from \"group\" order by group_name asc", conn))
                {

                    int id = 0;
                    string name = "";
                    List<string> usernames = new List<string>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["group_id"]);
                        name = reader["group_name"].ToString();
                        allGroups.Add(new GroupModel(id, name));
                    }
                }
            }
            return allGroups;
        }
    }
}