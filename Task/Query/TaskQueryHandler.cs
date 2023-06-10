namespace TaskManager.Task;


public interface IQueryHandler<in T> where T : class, IQuery
{
    void Handle(T query);
}

public class TaskQueryHandler : IQueryHandler<ListTasksByStatusQuery>, IQueryHandler<ListAllTasksOrderedByDueDateQuery>, IQueryHandler<IQuery>
{
    
    private readonly ITaskRepository _taskRepository;

    public TaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    

    public void Handle(ListTasksByStatusQuery query)
    {
        query.Results = _taskRepository.FindByState(query.Status);
    }

    public void Handle(ListAllTasksOrderedByDueDateQuery query)
    {
        query.Results = _taskRepository.FindAll();
    }

    public void Handle(IQuery query)
    {
        dynamic specificQuery = query;
        Handle(specificQuery);
    }
}