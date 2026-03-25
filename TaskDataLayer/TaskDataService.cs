using System.Collections.Generic;
using TaskMODEL;

namespace TaskDataLayer
{
    public class TaskDataService
    {
        
        public List<TaskModels> taskList = new List<TaskModels>();
        
        public void AddTask(TaskModels newTask)
        {
            taskList.Add(newTask);
        }

        public List<TaskModels> ReviewTasks()
        {
            return taskList;
        }
        
        public void UpdateTask(int index, string newName)
        {
            taskList[index].taskName = newName;
        }

        public void DeleteAll()
        {
            taskList.Clear();
        }
    }
}