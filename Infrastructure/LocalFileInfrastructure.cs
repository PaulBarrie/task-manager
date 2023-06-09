namespace TaskManager;

public interface ILocalFileInfrastructure<TO>
{
    void Write(TO content);
    void WriteLine(TO content);
    TO Read();  
}

public class LocalFileInfrastructure : ILocalFileInfrastructure<String>
{

    private readonly String filename;

    public LocalFileInfrastructure(string filename)
    {
        this.filename = filename;
    }

    public String Read()
    {
        if (!File.Exists(filename)) {
            throw new FileNotFoundException($"File {filename} not found");
        }
        var file = File.ReadAllText(filename);
        return file;
    }

    public void Write(String content)
    {
        using (FileStream fs = File.Open(filename, FileMode.OpenOrCreate))
        {
            var sw = new StreamWriter(fs);
            sw.Write(content);
        }
    }
    
    public void WriteLine(string content)
    {
        using (FileStream fs = File.Open(filename, FileMode.OpenOrCreate))
        {
            var sw = new StreamWriter(fs);
            sw.WriteLine(content);
        }
    }
}