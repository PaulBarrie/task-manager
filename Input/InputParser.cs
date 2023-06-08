namespace TaskManager.Input;

public interface IInputParser<in T, out TO>
{
    TO Parse(T input);
} 

public class InputParser : IInputManager<String[], IInput>
{
    
}