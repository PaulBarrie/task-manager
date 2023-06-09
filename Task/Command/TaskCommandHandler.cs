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
        var task = command.DueDate is null ? new Task(command.Description) : new Task(command.Description, command.DueDate);
        _taskRepository.Create(task);
        command.Id = task.Id;
    }

    public void Handle(UpdateTaskStatusCommand command)
    {
        var task = _taskRepository.Update(command.Id, command.Status);
        
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