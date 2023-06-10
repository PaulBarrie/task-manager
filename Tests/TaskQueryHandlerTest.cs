namespace TaskManager.Tests;

using NUnit.Framework;
using Moq;
using TaskManager.Task;
using System.Collections.Generic;

[TestFixture]
public class TaskQueryHandlerTest{

    private Mock<ITaskRepository> _mockTaskRepository;
    private TaskQueryHandler _taskQueryHandler;

    [SetUp]
    public void Setup()
    {
        _mockTaskRepository = new Mock<ITaskRepository>();
        _taskQueryHandler = new TaskQueryHandler(_mockTaskRepository.Object);
    }

    [Test]
    public void Handle_ListTasksByStatusQuery_CallsTaskRepositoryFindByState()
    {
        // Arrange
        var query = new ListTasksByStatusQuery("Todo");

        // Act
        _taskQueryHandler.Handle(query);

        // Assert
        _mockTaskRepository.Verify(r => r.FindByState(TaskState.Todo), Times.Once);
    }


    [Test]
    public void Handle_ListTasksByStatusQuery_SetsQueryResults()
    {
        // Arrange
        var query = new ListTasksByStatusQuery("Todo");
        var expectedResults = new List<Task>();

        _mockTaskRepository
            .Setup(r => r.FindByState(TaskState.Todo))
            .Returns(expectedResults);

        // Act
        _taskQueryHandler.Handle(query);

        // Assert
        Assert.AreEqual(expectedResults, query.Results);
    }

    [Test]
    public void Handle_ListAllTasksOrderedByDueDateQuery_CallsTaskRepositoryFindAll()
    {
        // Arrange
        var query = new ListAllTasksOrderedByDueDateQuery();

        // Act
        _taskQueryHandler.Handle(query);

        // Assert
        _mockTaskRepository.Verify(r => r.FindAll(), Times.Once);
    }

    [Test]
    public void Handle_ListAllTasksOrderedByDueDateQuery_SetsQueryResults()
    {
        // Arrange
        var query = new ListAllTasksOrderedByDueDateQuery();
        var expectedResults = new List<Task>();

        _mockTaskRepository
            .Setup(r => r.FindAll())
            .Returns(expectedResults);

        // Act
        _taskQueryHandler.Handle(query);

        // Assert
        Assert.AreEqual(expectedResults, query.Results);
    }


}