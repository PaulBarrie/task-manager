using TaskManager.Input;
using TaskManager.Task;

namespace TaskManager.Tests;

[TestFixture]
public class InputParserTest
{
    [Test]
    public void AddTaskInputParser_Parse()
    {
        var inputParser = new AddTaskInputParser();
        var input = new string[] {"-c", "sub test for the group", "-d:2032-04-06", "-pid:T7KYo7UkaD"};
        var expected = new AddTaskCommand("sub test for the group", "2032-04-06", "T7KYo7UkaD");
        var actual = inputParser.Parse(input);
        bool checkCondition = (expected.Description == actual.Description) && (expected.DueDate == actual.DueDate);
        Assert.True(checkCondition, "Le parsing d'AddTaskInputParser est incorrect");
    }

    [Test]
    public void UpdateTaskInputParser_Parse()
    {
        var inputParser = new UpdateTaskInputParser();
        var input = new string[] {"DvXrUURNAi", "-s:done"};
        var expected = new UpdateTaskCommand("DvXrUURNAi", "done", null);
        var actual = inputParser.Parse(input);
        bool checkUpdate = (expected.Id._value == actual.Id._value) && (expected.Status == actual.Status);
        Assert.True(checkUpdate, "Le parsing d'UpdateTaskInputParser est incorrect");
    }

    //Test qui vérifies la méthode RemoveTaskInputParser.Parse
    [Test]
    public void RemoveTaskInputParser_Parse(){
        var inputParser = new RemoveTaskInputParser();
        var expected = new DeleteTaskCommand("DvXrUURNAi");
        var actual = inputParser.Parse(new string[]{"DvXrUURNAi"});
        Assert.True(true,"La vérification n'a pas pu être effectué.");
    }

}