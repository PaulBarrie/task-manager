namespace TaskManager.Input;

public class InvalidInputArgumentException : Exception
{
    public InvalidInputArgumentException(string command) : base($"{command} is not a valid command")
    {
    }
}

public class InvalidAddInputArgumentException : Exception
{
    public InvalidAddInputArgumentException() : base("Missing required description after -c flag")
    {
    }
}

public class InvalidListInputArgumentException : Exception
{
    public InvalidListInputArgumentException(String msg) : base(msg)
    {}
}

public class InvalidUpdateInputArgumentException : Exception
{
    public InvalidUpdateInputArgumentException(String msg) : base(msg)
    {}
}

public class InvalidRemoveInputArgumentException : Exception
{
    public InvalidRemoveInputArgumentException(string message) : base(message)
    {
    }
}