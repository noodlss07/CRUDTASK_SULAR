using System.Collections.Generic;
using TaskMODEL;

namespace TaskDataLayer
{
    public class TaskDataService
    {
        public TaskJsonData jsonData = new TaskJsonData();

        public void AddTask(string name)
        {
            jsonData.taskList.Add(new TaskModels { taskName = name, previousName = "New Task" });
            jsonData.SaveData();
        }

        public void UpdateTask(int index, string oldName, string newName)
        {
            jsonData.taskList[index].taskName = newName;
            jsonData.taskList[index].previousName = oldName;
            jsonData.SaveData();
        }

        public void DeleteAll()
        {
            jsonData.taskList.Clear();
            jsonData.SaveData();
        }
    }
}
