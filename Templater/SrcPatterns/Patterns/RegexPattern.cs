using System.Text.RegularExpressions;

namespace Templater.Patterns;

public class Rgx: Pattern
{
    public Rgx(Regex regexp)
    {
        Execute = (text, position) =>
        {
            var match = regexp.Match(text.Substring(position));
            if (match.Success)
                return new PatternResult(match.Value, position+match.Value.Length);
            return null;
        };
    }
}