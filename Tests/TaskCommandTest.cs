namespace TaskManager.Tests;

using TaskManager.Infrastructure;
using TaskManager.Task;

[TestFixture]
public class TaskQueryTest
{
    private JsonFsTaskRepository taskRepository;
    private TaskCommandHandler taskCommandHandler;

    [SetUp]
    public void Setup()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        taskRepository = new JsonFsTaskRepository(new LocalFileInfrastructure(path + @"\resources\mock.json"));
        taskCommandHandler = new TaskCommandHandler(taskRepository);
    }

    [Test]
    public void AddTaskCommandTest(){

        
        Id id = new Id("7");
        AddTaskCommand taskCommand = new AddTaskCommand(id,"Test", "2023-06-10", null);

        taskCommandHandler.Handle(taskCommand);
        
        Assert.True(true);

    }

    [Test]
    public void UpdateTaskCommandTest(){

        UpdateTaskCommand TaskCommand = new UpdateTaskCommand("4","Pending", "2023-06-17");

        taskCommandHandler.Handle(TaskCommand);

        Task updatedTask = taskRepository.Find(new Id("4"));

        bool check = (updatedTask.State == TaskState.Pending && updatedTask.DueDate == DateTimeOffset.Parse("2023-06-17"));

        Assert.IsTrue(check, "Task not updated");

    }

    [Test]
    public void DeleteTaskCommandTest(){

        DeleteTaskCommand TaskCommand = new DeleteTaskCommand("3");

        taskCommandHandler.Handle(TaskCommand);
    }
}