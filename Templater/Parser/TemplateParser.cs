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
        var literals = _markdown
                .Split(SPLITER)
                .Where(literal => !string.IsNullOrWhiteSpace(literal))
                .Select(literal => literal.Trim())
                .ToArray();
        
        return _builder.Build();
    }

    public string GetMarkdown()
    {
        return _markdown;
    }
}