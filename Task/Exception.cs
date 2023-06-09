namespace TaskManager.Task;

public class TaskNotFoundException : Exception {
    public TaskNotFoundException(string message) : base(message) { }

}

public class InvalidTaskStatusException: Exception {
    public InvalidTaskStatusException(string status) : base($"{status} is not a valid task status") { }

}