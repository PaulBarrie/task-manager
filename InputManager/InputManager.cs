

public interface IInputManager<T, TO>
{
    TO Read(T args);
}

public class InputManager : IInputManager<String[], Input>
{
    public Input Read(String[] args)
    {
        var input = Console.ReadLine();

        var command = args[0] switch
        {
            "add" => AddCommand(args),
            _ => throw new ArgumentException("Invalid command"),
        };

        return command;


    }

    public Input AddCommand(String[] args)
    {
        if (args.Length < 3)
        {
            throw new ArgumentException("Invalid number of arguments");
        }

        var option = args[1];
        var value = args[2];

        if (isAddArgsValid(option, value))
        {
            return new Input()
            {
                Command = Command.Add,
                Args = new String[] { option, value }
            };
        }

        throw new ArgumentException("Invalid arguments");
    }

    public bool isAddArgsValid(String? option, String? value)
    {
        if (option == null || value == null)
        {
            throw new ArgumentException("Invalid option or value");
        }

        if (option != "-d" || option != "-c")
        {
            throw new ArgumentException("Invalid option");
        }

        if( option == "-d")
        {
            if (DateTime.TryParse(value, out DateTime date))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid date");
            }
        }

        return true;
    }
}


public interface InputADefinir<T> {
    public T Get();
}

public class AddInput : InputADefinir<AddInput> {
    public String description { get; set; }
    public String dateDue { get; set; }

    public AddInput Get()
    {
        return this;
    }
}




