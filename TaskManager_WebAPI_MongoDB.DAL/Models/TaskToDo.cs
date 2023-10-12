namespace TaskManager_WebAPI_MongoDB.DAL.Models
{
    public class TaskToDo
    {
        public TaskToDo(string name, int? value)
        {
            TaskId = Guid.NewGuid().ToString();
            Name = name;
            Value = value;
            Done = false;
            CreationDate = DateTime.Now;
            UpdateDate = null;
        }

        public string TaskId { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int? Value { get; private set; }
        public bool Done { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
