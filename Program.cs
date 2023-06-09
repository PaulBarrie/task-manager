using TaskManager.Input;
using TaskManager.Output;
using TaskManager.Task;

namespace TaskManager;

static class Program {
    private static readonly string TaskFileName = $"Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)/.consoleagenda/data.json";
    private static readonly string LogFileName = $"Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)/.consoleagenda/log.txt";
    
    private static readonly IInputParser<string[], object> InputParser = new InputParser();
    private static readonly ITaskRepository _taskRepository = new JsonFsTaskRepository(new LocalFileInfrastructure(TaskFileName));
    private static readonly TaskDispatcher _taskDispatcher = new(new TaskCommandHandler(_taskRepository), new TaskQueryHandler(_taskRepository));
    private static readonly OutputPorts _outputPorts = new(LogFileName);
    public static void Main(string[] args)
    {
        try
        {
            var commandQuery = InputParser.Parse(args);
            _taskDispatcher.Dispatch(commandQuery);
            _outputPorts.SuccessLoggerOutput.Render(args);
            _outputPorts.SuccessStandardOutput.Render(commandQuery);   
        }
        catch (Exception e)
        {
          _outputPorts.ErrorLoggerOutput.Render(new ErrorOutput(e.Message, args)); 
          _outputPorts.ErrorStandardOutput.Render(e.Message);
        }
    }
}