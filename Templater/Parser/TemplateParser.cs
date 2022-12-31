using System.Linq;

namespace Templater.Builder;

public class TemplateParser: TemplatePatterns
{
    private const char SPLITER = ';';
    
    private readonly string _markdown;
    private readonly TemplateBuilder _builder;

    public TemplateParser(string markdown): base()
    {
        _markdown = markdown;
        _builder = new();
    }

    public string Parse()
    {
        string id, tag, type, title, text;
        
        var literals = _markdown
                .Split(SPLITER)
                .Where(literal => !string.IsNullOrWhiteSpace(literal))
                .Select(literal => literal.Trim())
                .ToArray();

        foreach (var literal in literals)
        {
            
        }
        
        return _builder.Build();
    }

    public string GetMarkdown()
    {
        return _markdown;
    }
}