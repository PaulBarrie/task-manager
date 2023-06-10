namespace TaskManager.Infrastructure;

public class InvalidDbException : Exception {
    public InvalidDbException(string message) : base(message) { }
}