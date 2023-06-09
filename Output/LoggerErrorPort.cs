using TaskManager.Infrastructure;

namespace TaskManager.Output;

public class ErrorLoggerOutputPort : IOutputPort<ErrorOutput>
{
    
    private readonly LocalFileInfrastructure _localFileInfrastructure;
    private readonly Datetime _timer = new(null);


    public ErrorLoggerOutputPort(LocalFileInfrastructure localFileInfrastructure)
    {
        _localFileInfrastructure = localFileInfrastructure;
    }

    public void Render(ErrorOutput output)
    {
        _localFileInfrastructure.WriteLine($"[error][${_timer.Now()}]{String.Join(" ", output.Command)}:{output.ErrorMessage}");
    }
}

public record ErrorOutput(string ErrorMessage, string[] Command);