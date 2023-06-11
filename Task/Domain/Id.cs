using System.Dynamic;

namespace TaskManager.Task;

using System;
using System.Linq;

public class Id
{
    private static int _defaultIdSize = 10;
    private static readonly Random Random = new();
    public readonly String _value ;
    private List<String> _parentIds;

    public Id(int? size = null)
    {
        var sizeToUse = size ?? _defaultIdSize;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        _value = new string(Enumerable.Repeat(chars, sizeToUse)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
        _parentIds = new List<string>();
    }

    public Id(String value)
    {
        _value = value.Trim();
    }

    public Id(String value, List<String> parentIds)
    {
        _value = value;
        _parentIds = parentIds;
    }
    public string Get()
    {
        return _value;
    }
    public bool Equals(Id other)
    {
        return _value == other._value && _parentIds == other._parentIds; 
    }   
}