namespace TaskManager_WebAPI_MongoDB.API.DTO
{
    public class TaskToDoDTO
    {
        public string Name { get; set; } = string.Empty;
        public int? Value { get; set; }
        public bool? Done { get; set; }
    }
}
