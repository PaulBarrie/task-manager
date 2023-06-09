namespace TaskManager.Task;

public interface ITaskUseCases
{
    Task AddATaskToTaskList(Task task);
    Task AddSubTaskToTask(Task task, Task subTask);
    Task UpdateExistingTaskFrom(Task task);
    Task RemoveTaskFromList(Task task);
    List<Task> ListTasksByStatus(TaskStatus? status = null);
    List<Task> listAllTasksByDueDate();
}


public class TaskUseCases : ITaskUseCases
{

    private readonly ITaskRepository _taskRepository;
    
    public TaskUseCases(ITaskRepository taskRepository){
        _taskRepository = taskRepository;
    }

    
    public Task AddSubTaskToTask(Task task, Task subTask)
    {
        throw new NotImplementedException();
    }

    public Task AddATaskToTaskList(Task task)
    {
        
        throw new NotImplementedException();
    }

    public List<Task> ListTasksByStatus(TaskStatus? status = null)
    {
        throw new NotImplementedException();
    }

    public List<Task> listAllTasksByDueDate()
    {
        throw new NotImplementedException();
    }

    public Task RemoveTaskFromList(Task task)
    {
        throw new NotImplementedException();
    }

    public Task UpdateExistingTaskFrom(Task task)
    {
        throw new NotImplementedException();
    }
}