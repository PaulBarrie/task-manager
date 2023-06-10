
namespace TaskManager.Infrastructure;

public class Datetime
{
    private const String DefaultDateTimeFormat = "yyyy-MM-dd:HH'h'mm,ss";
    private readonly String _format = DefaultDateTimeFormat;
    
    public Datetime(String? format)
    {
        if (format != null)
        {
            _format = format;
        }    
    }
    
    public String Now()
    {
        var now = DateTime.Now;
        return now.ToString(_format);
    }
}