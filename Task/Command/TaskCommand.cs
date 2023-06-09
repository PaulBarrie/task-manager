namespace TaskManager.Task;

public interface ICommand
{
    Id Id { get; }
}

public class CreateCommand : ICommand
{
    public Id Id { get; }
    public readonly String Description;
    public readonly String DueDate;

    public CreateCommand(Id id, String description, String dueDate)
    {
        Id = id;
        Description = description;
        DueDate = dueDate;
    }

}

public class UpdateStatusCommand : ICommand
{
    public Id Id { get; }
    public readonly TaskStatus Status;

    public UpdateStatusCommand(Id id, TaskStatus status)
    {
        Id = id;
        Status = status;
    }

}

public class DeleteCommand : ICommand
{
    public DeleteCommand(Id id)
    {
        Id = id;
    }

    public Id Id { get; }
}