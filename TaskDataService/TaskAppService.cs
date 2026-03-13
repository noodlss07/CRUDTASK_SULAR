using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDataL;
using TaskMODEL;

namespace TaskBL
{
    public class TaskAppService
    {
        public TaskDataService dataService = new TaskDataService();

        public string CreateTask(string name)
        {
            if (dataService.taskList.Count >= 5)
            {
                return "Error: List is full!";
            }

            // Change TaskModel to TaskModels here to match your image
            TaskModels newTask = new TaskModels();
            newTask.Name = name;

            dataService.Save(newTask);
            return "Success: Task added!";
        }
    }
}


