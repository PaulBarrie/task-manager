using System.Text.Json;
using task_manager.Kernel;
namespace task_manager.Task;

public interface ITaskRepository
{
    Task? Find(Id idTask);
    List<Task> FindAll(SearchFilter filter);
    void Add(Task task);
    void Remove(Id idTask);
    void Update(Id idTask, TaskState newState);

}

public class JsonFsTaskRepository : ITaskRepository {
    
    private readonly ILocalFileInfrastructure<string, string> _localFileInfrastructure;
    private readonly string _taskFileName = $"Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)/.consoleagenda/data.json";

    public JsonFsTaskRepository(ILocalFileInfrastructure<string, string> localFileInfrastructure, String? taskFileName)
    {
        _localFileInfrastructure = localFileInfrastructure;
        if (taskFileName != null) {
            _taskFileName = taskFileName!;
        }
    }

    private List<Task> _getStoredTasks()
    {
        var file = _localFileInfrastructure.Read(_taskFileName);
        List<Task>? tasks = JsonSerializer.Deserialize<List<Task>>(file);
        if (tasks == null) {
            throw new InvalidDBException("Task file is not at JSON format");
        }
        return tasks!;
    }
    
    private void _storeTasks(List<Task> tasks)
    {
        var serializedTasks = JsonSerializer.Serialize(tasks);
        _localFileInfrastructure.Write(_taskFileName, serializedTasks);
    }

    public Task Find(Id idTask)
    {
        var tasks = _getStoredTasks();
        var foundTask = tasks!.Find(task => task.Id == idTask);
        if (foundTask == null) {
            throw new TaskNotFoundException($"Task with id {idTask.Get()} not found");
        }
        return foundTask;
    }

    public List<Task> FindAll(SearchFilter filter)
    {
        var tasks = _getStoredTasks();
        return tasks!.FindAll(task => task.State == filter.State);
    }

    public void Add(Task task)
    {
        var tasks = _getStoredTasks();
        tasks.Add(task);
        _storeTasks(tasks);
    }

    public void Remove(Id idTask)
    {
        var tasks = _getStoredTasks();
        var newTasks = tasks.Where(task => task.Id.Get() != idTask.Get());
        _storeTasks(newTasks.ToList());
    }

    public void Update(Id idTask, TaskState newState)
    {
        var tasks = _getStoredTasks();
        foreach (var t in tasks)
        {
            if (t.Id.Get() != idTask.Get()) continue;
            t.State = newState;
            _storeTasks(tasks);
            return;
        }
        throw new TaskNotFoundException($"Task with id {idTask.Get()} not found");
    }
}

public record SearchFilter(TaskState State) {}