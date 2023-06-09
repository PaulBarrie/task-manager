using TaskManager.Task;

namespace TaskManager.Output;

public class SuccessStandardOutput :
    IOutputPort<IQuery>,
    IOutputPort<ICommand>
{

    public void Render(object commandQuery)
    {
        if (commandQuery is IQuery query)
           Render(query);
        else if (commandQuery is ICommand command)
            Render(command);
    }
    public void Render(ICommand command)
    {
        dynamic specificCommand = command;
        Render(specificCommand);
    }
    
    public void Render(IQuery query)
    {
        dynamic specificQuery = query;
        Render(specificQuery);
    }
    
    private void Render(AddTaskCommand output)
    {
        Console.WriteLine($"Task with Id {output.Id} successfully added");
        
    }

    private void Render(UpdateTaskStatusCommand output)
    {
        Console.WriteLine($"Task with id {output.Id} successfully updated");
    }

    private void Render(DeleteTaskCommand output)
    {
        Console.WriteLine($"Task with id {output.Id} successfully deleted");
    }

    public void Render(GetTaskByIdQuery output)
    {
        renderTask(output.Result!);
    }

    private void Render(ListTasksByStatusQuery output)
    {
        foreach (var task in output.Results)
        {
            renderTask(task);
            Console.WriteLine("_________________________________________");
        }
    }

    private void Render(ListAllTasksOrderedByDueDateQuery output)
    {
        foreach (var task in output.Results)
        {
            renderTask(task);
            Console.WriteLine("_________________________________________");
        }
    }
    
    private static void renderTask(Task.Task task)
    {
        Console.WriteLine($"Status: {task.State} | Description: {task.Description} | DueDate: {task.DueDate}");
        if(task.SubTasks.Count == 0) return;
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Subtasks :");
        foreach (var subTask in task.SubTasks)
        {
            Console.WriteLine($"\t Status: {subTask.State} | Description: {subTask.Description} | DueDate: {subTask.DueDate}");
        }
    }
} 