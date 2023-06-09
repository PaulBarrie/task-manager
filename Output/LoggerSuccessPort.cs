using TaskManager.Infrastructure;

namespace TaskManager.Output;

public class SuccessLoggerOutputPort : IOutputPort<string[]>
{
    
    private readonly LocalFileInfrastructure _localFileInfrastructure;
    private readonly Datetime _timer = new(null);

    public SuccessLoggerOutputPort(LocalFileInfrastructure localFileInfrastructure)
    {
        _localFileInfrastructure = localFileInfrastructure;
    }

    public void Render(string[] output)
    {
        _localFileInfrastructure.WriteLine($"[ok+][{_timer.Now()}]{String.Join(" ", output)}");
    }
}