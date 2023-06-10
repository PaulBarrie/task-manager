using TaskManager.Task;

namespace TaskManager.Input;

public interface IInputParser<in T, out TO>
{
    TO Parse(T input);
} 

public class InputParser : IInputParser<String[], object>
{
    private readonly Dictionary<String, IInputParser<String[], object>> _inputParsers = new()
        {
            {"add", new AddTaskInputParser()},
            {"update", new UpdateTaskInputParser()},
            {"remove", new RemoveTaskInputParser()},
            {"list", new ListTaskInputParser()}
        };
    public object Parse(string[] input)
    {
        if (!_inputParsers.ContainsKey(input[0]))
        {
            throw new InvalidInputArgumentException("Invalid input");
        }
        var inputParser = _inputParsers[input[0]];
        return inputParser.Parse(input.Skip(1).ToArray());
    }
}

public class AddTaskInputParser : IInputParser<String[], AddTaskCommand>
{
    public AddTaskCommand Parse(string[] input)
    {
        var description = "";
        string? dueDate = null;
        String? parentId = null;
        
        for(int i=0; i<input.Length; i++)
        {
            if (input[i] == FlagsInput.DescriptionFlag)
            {
                if (i  == input.Length - 1)
                {
                    throw new InvalidAddInputArgumentException();
                }
                description = input[i + 1];
                continue;
            }
            if (input[i].StartsWith(FlagsInput.DueDateFlag))
            {
                dueDate = input[i].Substring(FlagsInput.DueDateFlag.Length);
            }
            if (input[i].StartsWith(FlagsInput.ParentTaskIdFlag))
            {
                parentId =  input[i].Substring(FlagsInput.ParentTaskIdFlag.Length);
            }
        }
        return new AddTaskCommand(description, dueDate, parentId);
    }
}

public class RemoveTaskInputParser : IInputParser<String[], DeleteTaskCommand>
{
    public DeleteTaskCommand Parse(string[] input)
    {
        if (input.Length == 0)
        {
            throw new InvalidRemoveInputArgumentException("Invalid remove input");
        } 
        return new DeleteTaskCommand(input[0]);
    }
}


public class UpdateTaskInputParser : IInputParser<String[], UpdateTaskCommand>
{

    public UpdateTaskCommand Parse(string[] input)
    {
        var id = input[0];
        String? parentId = null;
        String? status = null;
        String? dueDate = null;
        
        foreach (var entry in input.Skip(1).ToList())
        {
            if (entry.StartsWith(FlagsInput.StatusFlag))
            {
                status = entry.Substring(FlagsInput.StatusFlag.Length);
            } else if (entry.StartsWith(FlagsInput.DueDateFlag))
            {
                dueDate = entry.Substring(FlagsInput.DueDateFlag.Length);
            }
        }
        return new UpdateTaskCommand(id, status, dueDate);
    }
}

public class ListTaskInputParser : IInputParser<String[], IQuery>
{
    public IQuery Parse(string[] input)
    {
        if (input.Length == 0)
        {
            return new ListAllTasksOrderedByDueDateQuery();
        }

        if (input.Length == 1 && input[0].StartsWith(FlagsInput.StatusFlag))
        {
            return new ListTasksByStatusQuery(input[0].Substring(FlagsInput.StatusFlag.Length));
        }
        throw new InvalidInputArgumentException("Invalid input. Please use -s flag to filter by status");
    }
}
