using TaskManager_WebAPI_MongoDB.DAL.Data.Interfaces;

namespace TaskManager_WebAPI_MongoDB.DAL.Data
{
    public class DbSetting : IDbSetting
    {
        public string? DbName { get; set; }

        public string? DbConnectionString { get; set;  }
    }
}
