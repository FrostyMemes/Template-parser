namespace Templater.Patterns.Combinators;

public class SequenceLoyalPattern: Pattern
{
    public SequenceLoyalPattern(params Pattern[] patterns) 
    {
        Execute = (text, positiоn) =>
        {
            PatternResult? result = null;
            var currentPosition = positiоn;

            foreach (var pattern in patterns)
            {
                if ((result = pattern.Execute(text, currentPosition)) == null)
                    continue;

                currentPosition = positiоn;
            }

            return result;
        };
    }
}