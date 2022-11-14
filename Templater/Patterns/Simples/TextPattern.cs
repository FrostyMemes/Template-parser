namespace Templater.Patterns;

public class TextPattern: Pattern
{
    public TextPattern(string pattern)
    {
        Execute = (text, position) =>
        {
            if (text.Substring(position, pattern.Length) == pattern) 
                return new PatternResult(pattern, position+pattern.Length);
            
            return null;
        };
    }
}