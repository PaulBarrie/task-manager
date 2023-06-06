
public interface ITaskUseCases
{
    Task AddTask(Task task);
    Task AddSubTask(Task task, Task subTask);
    Task UpdateTask(Task task);
    Task RemoveTask(Task task);
    List<Task> ListTasks(TaskStatus? status = null);
}


public class TaskUseCases : ITaskUseCases
{

    private readonly ITaskRepository _taskRepository;
    
    public TaskUseCases(ITaskRepository taskRepository){
        this._taskRepository = taskRepository;
    }

    
    public Task AddSubTask(Task task, Task subTask)
    {
        throw new NotImplementedException();
    }

    public Task AddTask(Task task)
    {
        
        throw new NotImplementedException();
    }

    public List<Task> ListTasks(TaskStatus? status = null)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTask(Task task)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTask(Task task)
    {
        throw new NotImplementedException();
    }
}