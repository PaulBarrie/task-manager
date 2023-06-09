using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TaskManager;
using TaskManager.Kernel;
using TaskManager.Task;
using Task = TaskManager.Task.Task;

[TestFixture]
public class JsonFsTaskRepositoryTests
{
    private Mock<ILocalFileInfrastructure<String>> _localFileInfrastructure;
    private JsonFsTaskRepository _jsonFsTaskRepository;
    
    [SetUp]
    public void Setup()
    {
        var workingDirectory = Directory.GetCurrentDirectory().TrimEnd("/bin/Debug/net6.0".ToCharArray());
        _localFileInfrastructure = new Mock<ILocalFileInfrastructure<String>>();
        _jsonFsTaskRepository = new JsonFsTaskRepository(_localFileInfrastructure.Object);
    }

    [Test]
    public void TestAddNewTaskShouldSucceed()
    {
        // Arrange// Act

        // Assert
    }

    // Add more tests here to test other methods and scenarios...
}