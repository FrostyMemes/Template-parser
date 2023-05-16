namespace Templater.Patterns;

public class PatternResult
{
    public readonly string? Result;
    public readonly int EndPosition;
    public PatternResult(string? Result, int EndPosition)
    {
        this.Result = Result;
        this.EndPosition = EndPosition;
    }
}



