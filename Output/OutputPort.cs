using System.Data;
using TaskManager.Task;

namespace TaskManager.Output;

public interface IOutputPort<in T>
{
    public void Render(T output);
}

public class OutputPorts
{
    public ErrorLoggerOutput ErrorLoggerOutput { get; }
    public SuccessLoggerOutput SuccessLoggerOutput { get; }
    public ErrorStandardOutput ErrorStandardOutput { get; }
    public SuccessStandardOutput SuccessStandardOutput { get; }
    
    public OutputPorts(String fileLog)
    {
        var localFileInfrastructure = new LocalFileInfrastructure(fileLog);
        ErrorLoggerOutput = new ErrorLoggerOutput(localFileInfrastructure);
        SuccessLoggerOutput = new SuccessLoggerOutput(localFileInfrastructure);
        ErrorStandardOutput = new ErrorStandardOutput();
        SuccessStandardOutput = new SuccessStandardOutput();
    }
    
}