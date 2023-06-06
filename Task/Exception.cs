namespace task_manager.Task;

public class TaskNotFoundException : Exception {
    public TaskNotFoundException(string message) : base(message) { }

}