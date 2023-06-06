namespace taskmanager;

public class Task {

    private static TaskState DEFAULT_STATUS = TaskState.todo;

    public string id {get;}
    public readonly DateTimeOffset Created;
    public DateTimeOffset? DueDate { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }
    public List<Task> SubTasks { get; set; }

    static string GenerateRandomId()
    {
        Guid guid = Guid.NewGuid();
        string randomId = guid.ToString();
        return randomId;
    }

    public Task(string description) {
        this.id = GenerateRandomId();
        this.Description = description;
        this.Created = DateTimeOffset.Now;
        this.State = DEFAULT_STATUS;
        SubTasks = new List<Task>();
    }

}

public enum TaskState {
todo, pending, progress, done, cancelled, closed
}