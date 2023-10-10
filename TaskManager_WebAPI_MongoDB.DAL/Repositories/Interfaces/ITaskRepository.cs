namespace TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetByName(string name);
        void Insert(Task task);
        void Update(string taskId, Task task);
        void Delete(string taskId);
    }
}
