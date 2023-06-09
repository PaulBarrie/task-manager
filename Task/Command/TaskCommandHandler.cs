namespace TaskManager.Task;

public interface ICommandHandler<in T> where T : class, ICommand
{
    void Handle(T command);
}

public class TaskCommandHandler :  
    ICommandHandler<CreateCommand>, 
    ICommandHandler<UpdateStatusCommand>, 
    ICommandHandler<DeleteCommand>
{
    private readonly ITaskRepository _taskRepository;

    public TaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Handle(CreateCommand command)
    {
        throw new NotImplementedException();
    }

    public void Handle(UpdateStatusCommand command)
    {
        throw new NotImplementedException();
    }

    public void Handle(DeleteCommand command)
    {
        throw new NotImplementedException();
    }
}