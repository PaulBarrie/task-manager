namespace TaskManager.Task;


public interface IQuery
{
}
public class ListTasksByStatusQuery : IQuery
{
    public readonly TaskState Status;
    public List<Task> Results = new();
    public ListTasksByStatusQuery(String status)
    {
        try
        {
            Status = (TaskState)Enum.Parse(typeof(TaskState), status, ignoreCase: true);
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