using TaskMODEL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace TaskDataLayer
{
    public class TaskDBData : TaskDataService
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=TaskDb; Integrated Security=True; TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public TaskDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(TaskModels task)
        {
            string query = "INSERT INTO Tasks (TaskId, TaskName, PreviousName) VALUES (@Id, @Name, @Prev)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", task.TaskId);
            cmd.Parameters.AddWithValue("@Name", task.taskName);
            cmd.Parameters.AddWithValue("@Prev", task.previousName);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<TaskModels> GetTasks()
        {
            List<TaskModels> tasks = new List<TaskModels>();
            string query = "SELECT TaskId, TaskName, PreviousName FROM Tasks";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TaskModels task = new TaskModels();
                task.TaskId = Guid.Parse(reader["TaskId"].ToString());
                task.taskName = reader["TaskName"].ToString();
                task.previousName = reader["PreviousName"].ToString();
                tasks.Add(task);
            }
            sqlConnection.Close();
            return tasks;
        }

        public void Update(TaskModels task)
        {
            string query = "UPDATE Tasks SET TaskName = @Name, PreviousName = @Prev WHERE TaskId = @Id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Name", task.taskName);
            cmd.Parameters.AddWithValue("@Prev", task.previousName);
            cmd.Parameters.AddWithValue("@Id", task.TaskId);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteAll()
        {
            string query = "DELETE FROM Tasks";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
