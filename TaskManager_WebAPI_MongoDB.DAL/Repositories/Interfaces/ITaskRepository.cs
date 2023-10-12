using TaskManager_WebAPI_MongoDB.DAL.Models;

namespace TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskToDo>> GetAll();
        TaskToDo GetByName(string name);
        void Insert(TaskToDo task);
        void Update(string taskName, TaskToDo task);
        void Delete(string taskName);
    }
}
