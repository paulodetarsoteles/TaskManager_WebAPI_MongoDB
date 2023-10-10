namespace TaskManager_WebAPI_MongoDB.DAL.Data.Interfaces
{
    public interface IDbSetting
    {
        string DbName { get; }
        string DbConnectionString { get; }
    }
}
