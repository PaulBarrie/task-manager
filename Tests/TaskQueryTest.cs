namespace TaskManager.Tests;
using TaskManager.Task;


[TestFixture]
public class QueryCommandTest
{

[Test]
 public void ListTasksByStatusQuery_ShouldReturnCorrectStatus(){

    // Arrange
    var status = "Done";

    // Act
    var query = new ListTasksByStatusQuery(status);

    // Assert
    Assert.AreEqual(TaskState.Done, query.Status);

 }


// Le test throw une exception 

// [Test]
//  public void ListTasksByStatusQuery_ShouldThrowExceptionWhenStatusIsInvalid(){

//     // Arrange
//     var status = "Invalid";

//     // Act
//     var query = new ListTasksByStatusQuery(status);

//     // Assert
//     Assert.Throws<ArgumentException>(() => new ListTasksByStatusQuery(status));

//  }

    
}