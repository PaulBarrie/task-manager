namespace TaskManager.Input;

public interface IInput
{
    IInput Get();
}

public class AddTaskInput : IInput
{
    private readonly String _description;
    private readonly String? _dueDate;

    public AddTaskInput(string description, string? dueDate)
    {
        _description = description;
        _dueDate = dueDate;
    }

    public IInput Get()
    {
        return this;
    }
}

public class CreateSubTaskInput : IInput
{
    private readonly String _description;
    private readonly String _dueDate;
    private readonly String _parentId;

    public CreateSubTaskInput(string description, string dueDate, string parentId)
    {
        _description = description;
        _dueDate = dueDate;
        _parentId = parentId;
    }

    public IInput Get()
    {
        return this;
    }
}

public class UpdateTaskInput : IInput
{
    private readonly String _id;
    private readonly String? _status;
    private readonly String? _dueDate;

    public UpdateTaskInput(String id, String? status, String? dueDate)
    {
        _id = id;
        _status = status;
        _dueDate = dueDate;
    }

    public IInput Get()
    {
        return this;
    }
}

public class RemoveTaskInput : IInput
{
    private readonly String _id;

    public RemoveTaskInput(string id)
    {
        _id = id;
    }

    public IInput Get()
    {
        return this;
    }
}

public class ListTasksInput : IInput
{
    private readonly String? _status;

    public ListTasksInput(String? status)
    {
        _status = status;
    }

    public IInput Get()
    {
        return this;
    }
}

public class GetTaskByIdInput : IInput
{
    private readonly String _id;

    public GetTaskByIdInput(string id)
    {
        _id = id;
    }

    public IInput Get()
    {
        return this;
    }
}