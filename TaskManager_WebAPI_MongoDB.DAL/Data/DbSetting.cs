using TaskManager_WebAPI_MongoDB.DAL.Data.Interfaces;

namespace TaskManager_WebAPI_MongoDB.DAL.Data
{
    public class DbSetting : IDbSetting
    {
        public string DbName { get; } = string.Empty;

        public string DbConnectionString { get; } = string.Empty;
    }
}
