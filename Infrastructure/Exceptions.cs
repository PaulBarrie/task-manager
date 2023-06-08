namespace TaskManager.Kernel;

public class InvalidDBException : Exception {
    public InvalidDBException(string message) : base(message) { }
}