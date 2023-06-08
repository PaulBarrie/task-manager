namespace TaskManager.Task;

public class TaskNotFoundException : Exception {
    public TaskNotFoundException(string message) : base(message) { }

}