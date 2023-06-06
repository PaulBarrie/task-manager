using taskmanager;
using Task = taskmanager.Task;

public interface ITaskRepository
{
    Task Find(string idTask);
    List<Task> FindAll();
    void Add(Task task);
    void Remove(string idTask);
    void Update(TaskState newState, string idTask);

}

public class TaskRepository : ITaskRepository{

    private List<Task> tasks;

    public TaskRepository(){
        tasks = new List<Task>();
    }

    public void Add(Task task)
    {
       tasks.Add(task);
    }

    public Task Find(string idTask)
    {
        return tasks.FirstOrDefault(t => t.id == idTask);

        throw new ArgumentNullException();
    }

    public List<Task> FindAll()
    {
        return tasks;
    }

    public void Remove(string idTask)
    {
        Task task = tasks.FirstOrDefault(t => t.id == idTask);
        if (task != null)
        {
            task.State = TaskState.closed;
        }       
    }

    public void Update(TaskState newState, string idTask)
    {
            Task task = tasks.FirstOrDefault(t => t.id == idTask);
            if (task != null)
            {
                task.State = newState;
            }    
    }
}