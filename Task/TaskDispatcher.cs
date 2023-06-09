namespace TaskManager.Task;

public class TaskDispatcher
{
    private readonly ICommandHandler<ICommand> _commandHandler;
    private readonly IQueryHandler<IQuery> _queryHandler;

    public TaskDispatcher(ICommandHandler<ICommand> commandHandler, IQueryHandler<IQuery> queryHandler)
    {
        _commandHandler = commandHandler;
        _queryHandler = queryHandler;
    }

    public void Dispatch(object commandQuery)
    {
        if (commandQuery is ICommand command)
        {
            Dispatch(command);
        }
        else if (commandQuery is IQuery query)
        {
            Dispatch(query);
        }
    }

    private void Dispatch(ICommand command)
    {
        _commandHandler.Handle(command);
    }

    private void Dispatch(IQuery query)
    {
        _queryHandler.Handle(query);
    }
}