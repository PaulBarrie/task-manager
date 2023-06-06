using System.Dynamic;

namespace task_manager.Task;

using System;
using System.Linq;

public class Id
{
    private static int _defaultIdSize = 10;
    private static readonly Random Random = new();
    private readonly string _value;
    
    public Id(int? size = null)
    {
        var sizeToUse = size ?? _defaultIdSize;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        _value = new string(Enumerable.Repeat(chars, sizeToUse)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public string Get()
    {
        return _value;
    }
}