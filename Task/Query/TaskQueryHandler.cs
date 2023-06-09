namespace TaskManager.Task;


public interface IQueryHandler<in T> where T : class, IQuery
{
    void Handle(T query);
}

public class TaskQueryHandler : IQueryHandler<GetTaskByIdQuery>, IQueryHandler<ListTasksByStatusQuery>, IQueryHandler<ListAllTasksOrderedByDueDateQuery>, IQueryHandler<IQuery>
{
    
    private readonly ITaskRepository _taskRepository;

    public TaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Handle(GetTaskByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public void Handle(ListTasksByStatusQuery query)
    {
        throw new NotImplementedException();
    }

    public void Handle(ListAllTasksOrderedByDueDateQuery query)
    {
        throw new NotImplementedException();
    }

    public void Handle(IQuery query)
    {
        throw new NotImplementedException();
    }
}