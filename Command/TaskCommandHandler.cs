namespace TaskManager.Task;

public interface ICommandHandler<in T> where T : class, ICommand
{
    void Handle(T command);
}

public class TaskCommandHandler : ICommandHandler<AddTaskCommand>, ICommandHandler<UpdateTaskStatusCommand>, ICommandHandler<DeleteTaskCommand>, ICommandHandler<ICommand>
{
    private readonly ITaskRepository _taskRepository;

    public TaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Handle(AddTaskCommand command)
    {
        throw new NotImplementedException();
    }

    public void Handle(UpdateTaskStatusCommand command)
    {
        throw new NotImplementedException();
    }

    public void Handle(DeleteTaskCommand taskCommand)
    {
        throw new NotImplementedException();
    }

    public void Handle(ICommand command)
    {
        throw new NotImplementedException();
    }
}