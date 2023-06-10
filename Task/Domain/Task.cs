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
    public Task? FindTaskById(Id id)
    {
        if (Id.Equals(id))
        {
            return this;
        }
        foreach (var subTask in SubTasks)
        {
            var task = subTask.FindTaskById(id);
            if (task is not null) return task;
        }
        return null;
    }

    public void UpdateSubTask(Id id, Task newTask)
    {
        if (Id.Equals(id))
        {
            Description = newTask.Description;
            DueDate = newTask.DueDate;
            return;
        }
        foreach (var subTask in SubTasks)
        {
            var task = subTask.FindTaskById(id);
            if (task is not null)
            {
                SubTasks.Remove(task);
                SubTasks.Add(newTask);
                return;
            }
        }
    }

    public void DeleteSubTask(Id id)
    {
        if (Id.Equals(id))
        {
            return;
        }
        var newSubTasks = SubTasks;
        foreach (var subTask in SubTasks)
        {
            var task = subTask.FindTaskById(id);
            if (task is not null)
            {
                SubTasks.Remove(task);
            }
        }
    }
}

public enum TaskState {
Todo, Pending, Progress, Done, Cancelled, Closed
}