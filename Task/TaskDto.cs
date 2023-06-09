namespace TaskManager.Task;

public class TaskDto
{
    public string Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public  DateTimeOffset? DueDate { get; set; }
    public String Description { get; set; }
    public TaskState State { get; set; }
    public List<TaskDto> SubTasks  { get; set; }


    public TaskDto(String id, DateTimeOffset created, DateTimeOffset? dueDate, string description, TaskState state, List<TaskDto> subTasks)
    {
        Id = id;
        Created = created;
        DueDate = dueDate;
        Description = description;
        State = state;
        SubTasks = subTasks;
    }

    public static TaskDto FromTask(Task task)
    {
        TaskDto dto = new(
            task.Id.Get(),
            task.Created,
            task.DueDate,
            task.Description,
            task.State,
            task.SubTasks.Select(FromTask).ToList()
        );
        return dto;
    }

    public Task ToTask()
    {
        var subTasks = SubTasks != null ? SubTasks.Select(subTask => subTask.ToTask()).ToList() : new List<Task>();
        return new Task(
            new Id(Id),
            Description,
            Created,
            DueDate,
            State,
            subTasks
        );
    }
}