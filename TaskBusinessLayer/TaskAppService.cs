using TaskDataLayer;
using TaskMODEL;
using System.Collections.Generic;
using System;

namespace TaskBusinessLayer
{
    public class TaskAppService
    {
        private TaskDataService dbData = new TaskDBData();
        private TaskDataService jsonData = new TaskJsonData();

        public List<TaskModels> GetAllTasks()
        {
            return dbData.GetTasks();
        }

        public string CreateTask(string name)
        {
            if (GetAllTasks().Count >= 5) return "Error: List is full!";

            TaskModels newTask = new TaskModels();
            newTask.TaskId = Guid.NewGuid();
            newTask.taskName = name;
            newTask.previousName = "New Task";

            dbData.Add(newTask);
            jsonData.Add(newTask);

            return "Success: Task added to SQL and JSON!";
        }

        public string UpdateTaskLogic(int displayNum, string newName)
        {
            List<TaskModels> tasks = GetAllTasks();
            int index = displayNum - 1;
            if (index < 0 || index >= tasks.Count) return "Error: Invalid number.";

            TaskModels task = tasks[index];
            task.previousName = task.taskName;
            task.taskName = newName;
            
            dbData.Update(task);
            jsonData.Update(task);

            return "Success: Updated everywhere!";
        }

        public void ClearAll()
        {
            dbData.DeleteAll();
            jsonData.DeleteAll();
        }
    }
}
