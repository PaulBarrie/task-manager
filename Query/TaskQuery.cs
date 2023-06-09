namespace TaskManager.Task;


public interface IQuery
{
}
public class GetTaskByIdQuery : IQuery
{
    public readonly string Id;
    public Task? Result;

    public GetTaskByIdQuery(string id)
    {
        Id = id;
        Result = null;
    }
}

public class ListTasksByStatusQuery : IQuery
{
    public readonly TaskStatus Status;
    public List<Task> Results = new List<Task>();
    public ListTasksByStatusQuery(String status)
    {
        try
        {
            Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), status);
        } catch (ArgumentException)
        {
            throw new InvalidTaskStatusException(status);
        }
    }
}

public class ListAllTasksOrderedByDueDateQuery : IQuery
{
    public List<Task> Results = new List<Task>(); 
    public ListAllTasksOrderedByDueDateQuery()
    {
    }
}