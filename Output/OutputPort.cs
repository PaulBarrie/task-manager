using System.Data;
using TaskManager.Task;

namespace TaskManager.Output;

public interface IOutputPort<in T>
{
    public void Render(T output);
}

public class OutputPorts
{
    public ErrorLoggerOutputPort ErrorLoggerOutput { get; }
    public SuccessLoggerOutputPort SuccessLoggerOutput { get; }
    public ErrorStandardOutput ErrorStandardOutput { get; }
    public SuccessStandardOutput SuccessStandardOutput { get; }
    
    public OutputPorts(String fileLog)
    {
        var localFileInfrastructure = new LocalFileInfrastructure(fileLog);
        ErrorLoggerOutput = new ErrorLoggerOutputPort(localFileInfrastructure);
        SuccessLoggerOutput = new SuccessLoggerOutputPort(localFileInfrastructure);
        ErrorStandardOutput = new ErrorStandardOutput();
        SuccessStandardOutput = new SuccessStandardOutput();
    }
    
}