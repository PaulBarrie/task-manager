using Microsoft.VisualStudio.TestPlatform.Utilities;
using TaskManager.Task;
namespace TaskManager.Output;

public class ErrorStandardOutput : IOutputPort<String> {
    public void Render(string output)
    {
        Console.Error.WriteLine("An error occurred: " + output);
    }
}