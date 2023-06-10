using Microsoft.VisualBasic;

namespace TaskManager.Task;

public interface ICommand
{
    Id Id { get; }
}

public class AddTaskCommand : ICommand
{
    public Id Id { get; set; }
    public readonly String Description;
    public readonly String? DueDate;
    public readonly String? ParentTaskId;

    public AddTaskCommand(String description, String? dueDate, String? parentTaskId)
    {
        ParentTaskId = parentTaskId;
        Description = description;
        DueDate = dueDate;
    }

    public AddTaskCommand(Id id, String description, String? dueDate, String? parentTaskId)
    {
        Id = id;
        ParentTaskId = parentTaskId;
        Description = description;
        DueDate = dueDate;
    }
}


public class UpdateTaskCommand : ICommand
{
    public Id Id { get; }
    public readonly TaskState? Status;
    public readonly DateTimeOffset? DueDate;

    public UpdateTaskCommand(string id, string? status, string? dueDate)
    {
        Id = new Id(id);
        if (dueDate is not null) DueDate = DateTimeOffset.Parse(dueDate);
        if (status is null) return;
        try
        {
            Status = (TaskState)Enum.Parse(typeof(TaskState), status, ignoreCase: true);
        } catch (ArgumentException)
        {
            throw new InvalidTaskStatusException(status);
        }
    }

}

public class DeleteTaskCommand : ICommand
{
    public DeleteTaskCommand(String id)
    {
        Id = new Id(id);
    }

    public Id Id { get; }
}