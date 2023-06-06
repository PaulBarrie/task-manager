namespace task_manager.Kernel;

public class InvalidDBException : Exception {
    public InvalidDBException(string message) : base(message) { }
}