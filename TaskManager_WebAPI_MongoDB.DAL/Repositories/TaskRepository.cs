using MongoDB.Driver;
using TaskManager_WebAPI_MongoDB.DAL.Data.Interfaces;
using TaskManager_WebAPI_MongoDB.DAL.Models;
using TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces;

namespace TaskManager_WebAPI_MongoDB.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskToDo> _taskCollections;

        public TaskRepository(IDbSetting dbSetting)
        {
            MongoClient client = new(dbSetting.DbConnectionString);
            IMongoDatabase dataBase = client.GetDatabase(dbSetting.DbName);

            _taskCollections = dataBase.GetCollection<TaskToDo>(nameof(Task));
        }

        public async Task<IEnumerable<TaskToDo>> GetAll()
        {
            try
            {
                return await _taskCollections.Find(t => true)
                                             .ToListAsync()
                                             .WaitAsync(new TimeSpan(0, 0, 30));
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao acessar o banco de dados - {e.Message}");
            }
        }

        public Task<TaskToDo> GetByName(string name)
        {
            try
            {
                return _taskCollections.Find(t => t.Name == name)
                                       .FirstOrDefaultAsync()
                                       .WaitAsync(new TimeSpan(0, 0, 30));
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao acessar o banco de dados - {e.Message}");
            }
        }

        public void Insert(TaskToDo task)
        {
            throw new NotImplementedException();
        }

        public void Update(string taskId, TaskToDo task)
        {
            throw new NotImplementedException();
        }

        public void Delete(string taskId)
        {
            throw new NotImplementedException();
        }
    }
}
