using TaskDataLayer;
using TaskMODEL;

namespace TaskBusinessLayer
{
    public class TaskAppService
    {
        
        public TaskDataService data = new TaskDataService();

        public string CreateTask(string name)
        {
            if (data.taskList.Count >= 5)
            {
                return "Error: List is full!";
            }

            TaskModels newTask = new TaskModels();
            newTask.taskName = name;
            data.AddTask(newTask);
            return "Success: Task added!";
        }

        
        public string UpdateTaskLogic(int userNumber, string newName)
        {
            int index = userNumber - 1;

            if (index < 0 || index >= data.taskList.Count)
            {
                return "Error: Invalid number.";
            }

            data.UpdateTask(index, newName);
            return "Success: Task updated!";
        }
    }
}