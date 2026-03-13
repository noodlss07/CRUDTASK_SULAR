using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMODEL;

namespace TaskDL
{
    public class TaskDataService
    {

        public List<TaskModels> taskList = new List<TaskModels>();

        public void Save(TaskModels newTask)
        {
            taskList.Add(newTask);
        }

        public List<TaskModels> GetAll()
        {
            return taskList;
        }
    }
}