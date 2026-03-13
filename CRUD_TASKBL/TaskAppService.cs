using CRUD_TASKDL;
using CRUD_TASKMODELS;

namespace CRUD_TASKBL
{
    public class TaskAppService
    {
        private TaskDataService dataService = new TaskDataService();

        public string CreateTask(string name)
        {
            if (dataService.GetCount() >= 5) return "\nError: List is full!";

            TaskModel newTask = new TaskModel { Name = name };
            dataService.SaveTask(newTask);
            return "\nSuccess: Task added!";
        }

        public string UpdateTaskLogic(int userNumber, string newName)
        {
            int index = userNumber - 1;

            if (index < 0 || index >= dataService.GetCount())
            {
                return "\nError: Task does not exist!";
            }

            dataService.UpdateTask(index, newName);
            return "\nSuccess: Task updated!";
        }

        public TaskModel[] GetTasks() => dataService.GetAll();
        public int GetCount() => dataService.GetCount();
        public void Clear() => dataService.DeleteAll();
    }
}
