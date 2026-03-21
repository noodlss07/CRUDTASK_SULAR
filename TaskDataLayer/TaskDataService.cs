using System.Collections.Generic;
using TaskMODEL;

namespace TaskDataLayer
{
    public class TaskDataService
    {
        
        public List<TaskModels> taskList = new List<TaskModels>();
        
        public void SaveTask(TaskModels newTask)
        {
            taskList.Add(newTask);
        }

        public List<TaskModels> GetAllTasks()
        {
            return taskList;
        }
        
        public void UpdateTask(int index, string newName)
        {
            taskList[index].Name = newName;
        }

        public void DeleteAll()
        {
            taskList.Clear();
        }
    }
}