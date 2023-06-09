public record Input()
{
    public Command Command { get; init; }
    public String[]? Args { get; init; }
}