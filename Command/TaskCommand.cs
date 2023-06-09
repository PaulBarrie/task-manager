namespace TaskManager.Task;

public interface ICommand
{
    Id Id { get; }
}

public class AddTaskCommand : ICommand
{
    public Id Id { get; }
    public readonly String Description;
    public readonly String? DueDate;

    public AddTaskCommand(String description, String? dueDate)
    {
        Id = new Id();
        Description = description;
        DueDate = dueDate;
    }

}

public class UpdateTaskStatusCommand : ICommand
{
    public Id Id { get; }
    public readonly TaskStatus Status;

    public UpdateTaskStatusCommand(string id, string status)
    {
        Id = new Id(id);
        Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), status);
    }

}

public class DeleteTaskCommand : ICommand
{
    public DeleteTaskCommand(string id)
    {
        Id = new Id(id);
    }

    public Id Id { get; }
}