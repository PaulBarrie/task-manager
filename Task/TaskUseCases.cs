namespace task_manager.Task;

public interface ITaskUseCases
{
    void AddTask(Task task);
    Task AddSubTask(Task task, Task subTask);
    Task UpdateTask(Id idTask, TaskState newState);
    void RemoveTask(Task task);
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

    public void AddTask(Task task)
    {
        _taskRepository.Add(task);
    }

    public List<Task> ListTasks(TaskStatus? status = null)
    {
        return _taskRepository.FindAll(new SearchFilter((TaskState)status));
    }

    public void RemoveTask(Task task)
    {
        _taskRepository.Remove(task.Id);
    }

    public Task UpdateTask(Id idTask, TaskState newState)
    {
        return _taskRepository.Update(idTask, newState);
    }
}