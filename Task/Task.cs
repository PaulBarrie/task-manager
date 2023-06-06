namespace task_manager.Task;

public class Task {

    private static TaskState DEFAULT_STATUS = TaskState.Todo;

    public Id Id {get; set; }
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
        Id = new Id();
        Description = description;
        Created = DateTimeOffset.Now;
        State = DEFAULT_STATUS;
        SubTasks = new List<Task>();
    }

}

public enum TaskState {
Todo, Pending, Progress, Done, Cancelled, Closed
}