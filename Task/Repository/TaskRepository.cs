using System.Collections.Immutable;
using System.Text.Json;
using TaskManager.Infrastructure;

namespace TaskManager.Task;

public interface ITaskRepository
{
    Task Find(Id idTask);
    List<Task> FindByState(TaskState state);
    List<Task> FindAll();
    void Create(Task task);
    void Remove(Id idTask);
    void Update(Id idTask, Task newTask);

}

public class JsonFsTaskRepository : ITaskRepository
{

    private readonly ILocalFileInfrastructure<String> _localFileInfrastructure;

    public JsonFsTaskRepository(ILocalFileInfrastructure<String> localFileInfrastructure)
    {
        _localFileInfrastructure = localFileInfrastructure;
    }

    private List<Task> _getStoredTasks()
    {
        var file = _localFileInfrastructure.Read();
        List<TaskDto>? tasks = JsonSerializer.Deserialize<List<TaskDto>>(file);
        if (tasks == null)
        {
            throw new InvalidDbException("Task file is not at JSON format");
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
        foreach (var task in tasks)
        {
            var foundTask = task.FindTaskById(idTask);
            if (foundTask != null) return foundTask;
        }

        throw new TaskNotFoundException($"Task with id {idTask.Get()} not found");
    }

    public List<Task> FindByState(TaskState state)
    {
        var tasks = _getStoredTasks();
        return tasks!.FindAll(task => task.State == state);
    }


    public List<Task> FindAll()
    {
        var tasks = _getStoredTasks();
        return tasks.OrderBy(task => task.DueDate).ToList();
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
        for(int i=0; i < tasks.Count; i++)
        {
            if (tasks[i].Id.Get() == idTask.Get()) {
                var newTasks = tasks.Where(taskI => taskI.Id.Get() != idTask.Get()).ToList();
                newTasks.Add(tasks[i]);
                _storeTasks(newTasks);
                return;
            }
            tasks[i].DeleteSubTask(idTask);
        }
        _storeTasks(tasks);
    }

    public void Update(Id idTask, Task newTask)
    {
        var tasks = _getStoredTasks();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id.Get() == idTask.Get())
            {
                tasks[i] = newTask;
                _storeTasks(tasks);
                return;
            }

            tasks[i].UpdateSubTask(idTask, newTask);
        }

        _storeTasks(tasks);
    }
}

public record SearchFilter(TaskState State) {}