using System.Text.Json;
using TaskManager.Kernel;

namespace TaskManager.Task;

public interface ITaskRepository
{
    Task? Find(Id idTask);
    List<Task> FindAll(SearchFilter filter);
    void Create(Task task);
    void Remove(Id idTask);
    void Update(Id idTask, TaskState newState);

}

public class JsonFsTaskRepository : ITaskRepository {
    
    private readonly ILocalFileInfrastructure<String> _localFileInfrastructure;
    private readonly string _taskFileName = $"Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)/.consoleagenda/data.json";

    public JsonFsTaskRepository(ILocalFileInfrastructure<String> localFileInfrastructure)
    {
        _localFileInfrastructure = localFileInfrastructure;
    }

    private List<Task> _getStoredTasks()
    {
        var file = _localFileInfrastructure.Read();
        List<TaskDto>? tasks = JsonSerializer.Deserialize<List<TaskDto>>(file);
        if (tasks == null) {
            throw new InvalidDBException("Task file is not at JSON format");
        }
        return tasks.Select(dto => dto.ToTask()).ToList();
    }
    
    private void _storeTasks(List<Task> tasks)
    {
        var dtoTasks = tasks.Select(TaskDto.FromTask).ToList();
        var serializedTasks = JsonSerializer.Serialize(dtoTasks);
        _localFileInfrastructure.Write(serializedTasks);
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

    public void Create(Task task)
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