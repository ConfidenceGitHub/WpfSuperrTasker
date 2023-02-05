using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSuperrTasker.MVVM.Model;

namespace WpfSuperrTasker.Core
{
    public static class DataBase
    {
        private static SqliteConnection sql;
        public delegate void AddNewTask(UserTask userTask);
        public static event AddNewTask OnAddNewTask;

        public delegate void RemoveTask(ulong id);
        public static event RemoveTask OnRemoveTask;

        static DataBase()
        {
            sql = new SqliteConnection("Data source=Data.db");
            sql.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = sql;
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS 'Task'
            (
                'Id'            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE ,
                'Name'          TEXT NOT NULL,
                'Description'   TEXT NOT NULL
            )";
            cmd.ExecuteNonQuery();
        }

        public static void RemoveUserTask(ulong id)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = sql;
            cmd.CommandText = $"DELETE FROM Task WHERE Id = {id}";
            int result = cmd.ExecuteNonQuery();
            if (result >0)
            {
                //if (OnRemoveTask != null)
                //{
                //    OnRemoveTask(id);
                //}
                OnRemoveTask?.Invoke(id);
            }
        }

        public static ulong Add(UserTask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = sql;
            cmd.CommandText = @"INSERT INTO Task
            (Name, Description)
             Values
            (@Name, @Description); SELECT last_insert_rowid()";
            cmd.Parameters.AddWithValue("@Name", task.Name);
            cmd.Parameters.AddWithValue("@Description", task.Description);
            cmd.Prepare();

            ulong result = Convert.ToUInt64(cmd.ExecuteScalar());

            if (result >= 0)
            {
                UserTask AddedTask = new UserTask(result)
                {
                    Name = task.Name,
                    Description = task.Description,
                    Date = task.Date,
                };
                OnAddNewTask?.Invoke(AddedTask);
            }
            return result;
        }


        public static List<UserTask> GetTasks(string search)
        {
            
            List<UserTask> tasks = new List<UserTask>(100);

            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = sql;
            if (search != null && search.Length > 0)
            {
                search = search.Replace("'%", "").Replace("%'", "");
                cmd.CommandText = $"SELECT * FROM Task WHERE Name LIKE '%{search}%'";
            }
            else
            {
                cmd.CommandText = $"SELECT * FROM Task";
            }
         
            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                tasks.Add(new UserTask(Convert.ToUInt64(result["Id"]))
                {
                    Description = (string)result["Description"],
                    Name = (string)result["Name"]
                });
            }
            return tasks;
        }

        public static UserTask GetTasks(ulong id)
        {

            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = sql;
            cmd.CommandText = $"SELECT * FROM Task WHERE Id = {id}";
            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                return new UserTask(Convert.ToUInt64(result["Id"]))      
                {
                    Description = (string)result["Description"],
                    Name = (string)result["Name"]
                };
            }
            return null;
        }
        
    }
}
