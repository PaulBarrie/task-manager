namespace task_manager;

public interface ILocalFileInfrastructure<in T, TO>
{
    void Write(TO content, T filename);
    TO Read(T filename);  
}

public class LocalFileInfrastructure : ILocalFileInfrastructure<String, String>
{
    public String Read(String filename)
    {
        if (!File.Exists(filename)) {
            throw new FileNotFoundException($"File {filename} not found");
        }
        return File.ReadAllText(filename);
    }

    public void Write(String content, String filename)
    {
        FileStream fs = File.Open(filename, FileMode.OpenOrCreate);
        var sw = new StreamWriter(fs);
        sw.Write(content);
    }
}