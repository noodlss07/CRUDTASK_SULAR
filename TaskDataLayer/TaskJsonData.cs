using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskMODEL;

namespace TaskDataLayer
{
    public class TaskJsonData
    {
        public List<TaskModels> taskList = new List<TaskModels>();
        
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreatedTasks.json");

        public TaskJsonData() { LoadData(); }

        public void SaveData()
        {
            string json = JsonSerializer.Serialize(taskList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public void LoadData()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                taskList = JsonSerializer.Deserialize<List<TaskModels>>(json) ?? new List<TaskModels>();
            }
        }
    }
}
