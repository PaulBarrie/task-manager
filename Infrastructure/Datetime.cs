using static System.DateTime;

namespace TaskManager.Infrastructure;

public class Datetime
{
    private static String _defaultDateTimeFormat = "yyyy-MM-dd HHhmm,ss";
    private String _format = _defaultDateTimeFormat;
    
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