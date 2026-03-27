using System.Collections.Generic;
using TaskMODEL;

namespace TaskDataLayer
{
    public interface TaskDataService
    {
        void Add(TaskModels task);
        List<TaskModels> GetTasks();
        void Update(TaskModels task);
        void DeleteAll();
    }
}
