using TaskManager.Infrastructure;
using TaskManager.Input;
using TaskManager.Output;
using TaskManager.Task;

namespace TaskManager;

static class Program {
    private static readonly string UserHomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private static readonly string TaskFileName = Path.Combine(UserHomePath, ".consoleagenda/data.json");
    private static readonly string LogFileName = Path.Combine(UserHomePath, ".consoleagenda/log.txt");
    
    private static readonly IInputParser<string[], object> InputParser = new InputParser();
    private static readonly ITaskRepository TaskRepository = new JsonFsTaskRepository(new LocalFileInfrastructure(TaskFileName));
    private static readonly TaskDispatcher TaskDispatcher = new(new TaskCommandHandler(TaskRepository), new TaskQueryHandler(TaskRepository));
    private static readonly OutputPorts OutputPorts = new(LogFileName);
    public static void Main(string[] args)
    {
        try
        {
            //args = new string[] {"update", "DvXrUURNAi", "-s:done"};
            args = new string[] {"remove", "5WuW7nhVj0"};
            //args = new string[] {"add", "-pid:T7KYo7UkaD", "-c", "sub test for Luigi and Sonia"};
            //args = new[] {"list"};
            //args = new[] {"update", "DvXrUURNAi", "-d:2032-04-06"};
            
            var commandQuery = InputParser.Parse(args);
            TaskDispatcher.Dispatch(commandQuery);
            OutputPorts.SuccessLoggerOutput.Render(args);
            OutputPorts.SuccessStandardOutput.Render(commandQuery);
        }
        catch (Exception e)
        {
          OutputPorts.ErrorLoggerOutput.Render(new ErrorOutput(e.Message, args)); 
          OutputPorts.ErrorStandardOutput.Render(e.Message);
        }
    }
}