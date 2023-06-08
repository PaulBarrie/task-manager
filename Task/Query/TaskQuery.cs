namespace TaskManager.Task;

public class GetTaskByIdQuery
{
    public readonly string Id;

    public GetTaskByIdQuery(string id)
    {
        Id = id;
    }
}

public class GetTasksByStatusQuery
{
    public readonly TaskStatus Status;

    public GetTasksByStatusQuery(TaskStatus status)
    {
        Status = status;
    }
}