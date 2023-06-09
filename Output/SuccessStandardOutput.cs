using TaskManager.Task;

namespace TaskManager.Output;


/*
public class SuccessStandardOutput : IOutputPort<Task.Task>, IOutputPort<List<Task.Task>>, IOutputPort<String>
{
    public void Render(Task.Task output)
    {
        renderTask(output);
    }

    public void Render(List<Task.Task> output)
    {
        
    }

    public void Render(string output)
    {
        Console.WriteLine(output);
    }

    
}
*/

public class SuccessStandardOutput :
    IOutputPort<ICommand>,
    IOutputPort<IQuery>,
    IOutputPort<AddTaskCommand>,
    IOutputPort<UpdateTaskStatusCommand>,
    IOutputPort<DeleteTaskCommand>,
    IOutputPort<GetTaskByIdQuery>,
    IOutputPort<ListTasksByStatusQuery>,
    IOutputPort<ListAllTasksOrderedByDueDateQuery>
{
    public void Render(ICommand output)
    {
        switch (typeof(Output))
        {
            AddTaskCommand
        }
    }

    public void Render(IQuery output)
    {
        throw new NotImplementedException();
    }
    public void Render(AddTaskCommand output)
    {
        Console.WriteLine($"Task with Id {output.Id} successfully added");
        
    }

    public void Render(UpdateTaskStatusCommand output)
    {
        Console.WriteLine($"Task with id {output.Id} successfully updated");
    }

    public void Render(DeleteTaskCommand output)
    {
        Console.WriteLine($"Task with id {output.Id} successfully deleted");
    }

    public void Render(GetTaskByIdQuery output)
    {
        renderTask(output.Result!);
    }

    public void Render(ListTasksByStatusQuery output)
    {
        foreach (var task in output.Results)
        {
            renderTask(task);
            Console.WriteLine("_________________________________________");
        }
    }

    public void Render(ListAllTasksOrderedByDueDateQuery output)
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