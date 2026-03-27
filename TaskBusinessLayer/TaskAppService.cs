using TaskDataLayer;
using TaskMODEL;

namespace TaskBusinessLayer
{
    public class TaskAppService
    {
        public TaskDataService data = new TaskDataService();

        public string CreateTask(string name)
        {
            if (data.jsonData.taskList.Count >= 5) return "Error: List is full!";
            data.AddTask(name);
            return "Success: Task added!";
        }

        public string UpdateTaskLogic(int userNumber, string newName)
        {
            int index = userNumber - 1;
            if (index < 0 || index >= data.jsonData.taskList.Count) return "Error: Invalid number.";

            
            string oldName = data.jsonData.taskList[index].taskName;

            
            data.UpdateTask(index, oldName, newName);

            return $"Success: Updated '{oldName}' to '{newName}'!";
        }
    }
}
