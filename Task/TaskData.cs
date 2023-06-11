namespace TaskManager.Task;

public class TaskData
{
    public string Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public  DateTimeOffset? DueDate { get; set; }
    public String Description { get; set; }
    public TaskState State { get; set; }
    public List<TaskData> SubTasks  { get; set; }


    public TaskData(String id, DateTimeOffset created, DateTimeOffset? dueDate, string description, TaskState state, List<TaskData> subTasks)
    {
        Id = id;
        Created = created;
        DueDate = dueDate;
        Description = description;
        State = state;
        SubTasks = subTasks;
    }

    public static TaskData FromTask(Task task)
    {
        TaskData data = new(
            task.Id.Get(),
            task.Created,
            task.DueDate,
            task.Description,
            task.State,
            task.SubTasks.Select(FromTask).ToList()
        );
        return data;
    }

    public Task ToTask()
    {
        var subTasks = new List<Task>();
        if (SubTasks != null)
        {
            subTasks = SubTasks.Select(subTask => subTask.ToTask()).ToList();
        }
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