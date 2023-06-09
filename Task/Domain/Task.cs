namespace TaskManager.Task;

public class Task {

    private static TaskState DEFAULT_STATUS = TaskState.Todo;

    public Id Id {get; set; }
    public readonly DateTimeOffset Created;
    public DateTimeOffset? DueDate { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }
    public List<Task> SubTasks { get; set; }
    

    public Task(string description)
    {
        Id = new Id();
        Description = description;
        Created = DateTimeOffset.Now;
        State = DEFAULT_STATUS;
        SubTasks = new List<Task>();
    }

    public Task(string description, String dueDate) {
        Id = new Id();
        Description = description;
        Created = DateTimeOffset.Now;
        DueDate = DateTimeOffset.Parse(dueDate);
        State = DEFAULT_STATUS;
        SubTasks = new List<Task>();
    }
    
    public Task(Id id, String description, DateTimeOffset created, DateTimeOffset? dueDate, TaskState taskState, List<Task> subTasks)
    {
        Id = id;
        Description = description;
        Created = created;
        DueDate = dueDate;
        State = taskState;
        SubTasks = subTasks;
    }
}

public enum TaskState {
Todo, Pending, Progress, Done, Cancelled, Closed
}