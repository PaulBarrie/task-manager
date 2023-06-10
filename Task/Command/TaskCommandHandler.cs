namespace TaskManager.Task;

public interface ICommandHandler<in T> where T : class, ICommand
{
    void Handle(T command);
}

public class TaskCommandHandler : ICommandHandler<AddTaskCommand>, ICommandHandler<UpdateTaskCommand>, ICommandHandler<DeleteTaskCommand>, ICommandHandler<ICommand>
{
    private readonly ITaskRepository _taskRepository;

    public TaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Handle(AddTaskCommand command)
    {
        var task = command.DueDate is null ? new Task(command.Description) : new Task(command.Description, command.DueDate);
        if (command.ParentTaskId == null)
        {
            _taskRepository.Create(task);
        }
        else
        {
            var parentId = new Id(command.ParentTaskId);
            var parentTask = _taskRepository.Find(parentId);
            parentTask.SubTasks.Add(task);
            _taskRepository.Update(parentId, parentTask);
        }
        command.Id = task.Id;
    }

    public void Handle(UpdateTaskCommand command)
    {
        var task = _taskRepository.Find(command.Id);
        if (command.DueDate is not null) task.DueDate = command.DueDate.Value;
        if (command.Status is not null) task.State = command.Status.Value;
        _taskRepository.Update(task.Id, task);
    }

    public void Handle(DeleteTaskCommand command)
    {
        _taskRepository.Remove(command.Id);
    }

    public void Handle(ICommand command)
    {
        dynamic specificCommand = command;
        Handle(specificCommand);
    }
}