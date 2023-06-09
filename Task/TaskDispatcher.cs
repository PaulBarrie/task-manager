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
        dynamic specificCommandQuery = commandQuery;
        Dispatch(specificCommandQuery);
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