using TaskManager_WebAPI_MongoDB.DAL.Models;

namespace TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskToDo>> GetAll();
        Task<TaskToDo> GetByName(string name);
        Task<TaskToDo> Insert(TaskToDo task);
        Task<TaskToDo> Update(string taskId, TaskToDo task);
        void Delete(string taskId);
    }
}
