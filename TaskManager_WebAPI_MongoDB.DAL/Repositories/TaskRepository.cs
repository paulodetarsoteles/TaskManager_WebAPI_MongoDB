using TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces;

namespace TaskManager_WebAPI_MongoDB.DAL.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Task task)
        {
            throw new NotImplementedException();
        }

        public void Update(string taskId, Task task)
        {
            throw new NotImplementedException();
        }

        public void Delete(string taskId)
        {
            throw new NotImplementedException();
        }
    }
}
