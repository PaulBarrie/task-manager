using Task = task_manager.Task.Task;

public interface IOutputCommande{
    public string Read();
}

public class OutputCommande : IOutputCommande{
    List<Task> tasks = new List<Task>();

    public string Read(){
        string command = "";
        foreach (Task task in tasks){
            command += task.ToString();
            command += "\n";
        }

        return command;
    }
}