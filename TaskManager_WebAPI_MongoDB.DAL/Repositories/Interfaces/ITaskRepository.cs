using TaskManager_WebAPI_MongoDB.DAL.Models;

namespace TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskToDo>> GetAll();
        Task<TaskToDo> GetByName(string name);
        void Insert(TaskToDo task);
        void Update(string taskId, TaskToDo task);
        void Delete(string taskId);
    }
}
