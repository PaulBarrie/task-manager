namespace TaskManager.Input;

public interface IInputParser<in T, out TO>
{
    TO Parse(T input);
} 

public class InputParser : IInputParser<String[], IInput>
{
    private readonly Dictionary<String, IInputParser<String[], IInput>> _inputParsers = new()
        {
            {"add", new AddTaskInputParser()},
            {"update", new UpdateTaskInputParser()},
            {"remove", new RemoveTaskInputParser()},
            {"list", new ListTaskInputParser()}
        };
    public IInput Parse(string[] input)
    {
        if (!_inputParsers.ContainsKey(input[0]))
        {
            throw new InvalidInputArgumentException("Invalid input");
        }
        var inputParser = _inputParsers[input[0]];
        return inputParser.Parse(input.Skip(1).ToArray());
    }
}

public class AddTaskInputParser : IInputParser<String[], AddTaskInput>
{
    private static readonly String _descriptionFlag = "-c";
    private static readonly String _dueDateFlag = "-d:";
    public AddTaskInput Parse(string[] input)
    {
        var description = "";
        string? dueDate = null;
        for(int i=0; i<input.Length; i++)
        {
            if (input[i] == _descriptionFlag)
            {
                if (i  == input.Length - 1)
                {
                    throw new InvalidAddInputArgumentException();
                }
                description = input[i + 1];
                continue;
            }
            if (input[i].StartsWith(_dueDateFlag))
            {
                dueDate = input[i].Substring(_dueDateFlag.Length);
            }
        }
        return new AddTaskInput(description, dueDate);
    }
}

public class RemoveTaskInputParser : IInputParser<String[], RemoveTaskInput>
{
    public RemoveTaskInput Parse(string[] input)
    {
        if (input.Length != 1)
        {
            throw new InvalidRemoveInputArgumentException("Invalid remove input");
        }
        return new RemoveTaskInput(input[0]);
    }
}


public class UpdateTaskInputParser : IInputParser<String[], UpdateTaskInput>
{
    private static readonly String _statusFlag = "-s";
    private static readonly String _dueDateFlag = "-d";
    public UpdateTaskInput Parse(string[] input)
    {
        var id = input[0];
        String? status = null;
        String? dueDate = null;
        
        foreach (var entry in input.Skip(1).ToList())
        {
            if (entry.StartsWith(_statusFlag))
            {
                status = entry.Substring(_statusFlag.Length);
            } else if (entry.StartsWith(_dueDateFlag))
            {
                dueDate = entry.Substring(_dueDateFlag.Length);
            }
        }
        if (status == null && dueDate == null)
        {
            throw new InvalidUpdateInputArgumentException("Nothing to update. Please use -s or -d flag");
        }
        return new UpdateTaskInput(id, status, dueDate);
    }
}

public class ListTaskInputParser : IInputParser<String[], ListTasksInput>
{
    private static readonly String _statusFlag = "-s";
    public ListTasksInput Parse(string[] input)
    {
        if (input.Length == 0)
        {
            return new ListTasksInput(null);
        }

        if (input.Length == 1 && input[0].StartsWith(_statusFlag))
        {
            return new ListTasksInput(input[0].Substring(_statusFlag.Length));
        }
        throw new InvalidInputArgumentException("Invalid input. Please use -s flag to filter by status");
    }
}
