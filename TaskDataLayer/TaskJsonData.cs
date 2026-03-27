using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TaskMODEL;

namespace TaskDataLayer
{
    public class TaskJsonData : TaskDataService
    {
        private List<TaskModels> taskList = new List<TaskModels>();
        private string _jsonFileName = AppDomain.CurrentDomain.BaseDirectory + "/TasksData.json";

        public TaskJsonData()
        {
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();
            if (taskList.Count <= 0)
            {
                TaskModels seed = new TaskModels();
                seed.TaskId = Guid.NewGuid();
                seed.taskName = "Sample Task";
                seed.previousName = "New Task";
                taskList.Add(seed);
                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (FileStream outputStream = File.Create(_jsonFileName))
            {
                JsonWriterOptions options = new JsonWriterOptions();
                options.Indented = true;
                using (Utf8JsonWriter writer = new Utf8JsonWriter(outputStream, options))
                {
                    JsonSerializer.Serialize(writer, taskList);
                }
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName)) return;
            using (StreamReader reader = File.OpenText(_jsonFileName))
            {
                string content = reader.ReadToEnd();
                if (content != "")
                {
                    taskList = JsonSerializer.Deserialize<List<TaskModels>>(content).ToList();
                }
            }
        }

        public void Add(TaskModels task) { taskList.Add(task); SaveDataToJsonFile(); }
        public List<TaskModels> GetTasks() { RetrieveDataFromJsonFile(); return taskList; }
        public void DeleteAll() { taskList.Clear(); SaveDataToJsonFile(); }
        public void Update(TaskModels task) { SaveDataToJsonFile(); }
    }
}
