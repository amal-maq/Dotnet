using SmartTaskManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartTaskManager.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDb>> GetAllTasksAsync();
        Task<TaskDb> GetTaskByIdAsync(int id);
        Task<TaskDb> CreateTaskAsync(TaskDb task);
        Task<TaskDb> UpdateTaskAsync(int id, TaskDb task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
