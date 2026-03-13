using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMODEL;

namespace TaskDataL
{
    public class TaskDataService
    {

        public List<TaskModels> taskList = new List<TaskModels>();

        public void SaveTask(TaskModels task)
        {
            taskList.Add(task);
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
