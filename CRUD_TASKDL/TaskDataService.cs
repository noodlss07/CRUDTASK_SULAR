using CRUD_TASKMODELS;

namespace CRUD_TASKDL
{
    public class TaskDataService
    {
        private TaskModel[] tasks = new TaskModel[5];
        private int taskCount = 0;

        public void SaveTask(TaskModel newTask)
        {
            tasks[taskCount] = newTask;
            taskCount++;
        }

        public void UpdateTask(int index, string newName)
        {
            tasks[index].Name = newName;
        }

        public TaskModel[] GetAll() => tasks;
        public int GetCount() => taskCount;

        public void DeleteAll()
        {
            tasks = new TaskModel[5];
            taskCount = 0;
        }
    }
}
