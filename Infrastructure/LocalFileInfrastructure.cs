namespace TaskManager.Infrastructure;

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
        var directory = Path.GetDirectoryName(filename)!;
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
        }
        if (!File.Exists(filename) && Path.GetExtension(filename).ToLower() == ".json")
        {
            File.WriteAllText(filename, "[]");
        }
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
        using FileStream fs = File.Open(filename, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(content);
        sw.Close();
    }
    
    public void WriteLine(string content)
    {
        using FileStream fs = File.Open(filename, FileMode.OpenOrCreate);
        var sw = new StreamWriter(fs);
        sw.WriteLine(content);
        sw.Close();
    }
}