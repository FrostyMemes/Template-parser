using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Templater.Builder;

public class TemplateParser: TemplatePatterns
{
    private const char LITRAL_SPLITER = ';';
    
    private readonly string _markdown;
    private readonly TemplateBuilder _builder;

    public TemplateParser(string markdown): base()
    {
        _markdown = markdown;
        _builder = new();
    }

    public string Parse()
    {
        StringBuilder temp = new ();
        List<string> keys = new ();
        string id, tag, type, title, text;
        string literalKey, litrealBody;

        _builder.Clear();
        
        var literals = _markdown
                .Split(LITRAL_SPLITER)
                .Where(literal => !string.IsNullOrWhiteSpace(literal))
                .Select(literal => literal.Trim())
                .ToArray();
        
        foreach (var literal in literals)
        {
            temp.Clear();
            
            var literalParts = literal.Split(':');
            literalKey = literalParts[0].Trim();
            litrealBody = literalParts[1].Trim();
            
            temp.Append("\n");
            title = literalKey;
            
            if (!IsNull(ptrMarksArea.Execute(litrealBody, 0).Result))
            {
                var markGroup = ptrMarkGroupWords.Matches(litrealBody);
                tag = (markGroup.Count > 1) ? "textarea" : "input";
                
                foreach (Match match in markGroup)
                {
                    text = ptrDuoMarkContent.Execute(match.Value, 0).Result;
                    temp.Append((String.IsNullOrEmpty(text)) ? "\n": $"{text}\n");
                }
                
                _builder
                    .AddTag("div")
                    .AddAttribute("class", "form-floating mb-3")
                    .AddTag(tag)
                    .AddAttribute("class", "form-control")
                    .AddAttribute("name", literalKey)
                    .AddAttribute("id", literalKey)
                    .AddAttribute("placeholder", title)
                    .AddText((tag == "input")
                        ? $" value={temp}>"
                        : $">{temp} </{tag}>")
                    .AddTag("label")
                    .AddAttribute("for", literalKey)
                    .AddText(title)
                    .AddTag("/label")
                    .AddTag("/div");
            }
            else
            {
                var options = litrealBody
                    .Split(',')
                    .Where(option => !string.IsNullOrWhiteSpace(option))
                    .Select(option => option.Trim())
                    .ToArray();
                
                if (!IsNull(ptrVerticalBraceArea.Execute(options[0], 0).Result)) 
                {
                    foreach(var option in options)
                    {
                        _builder
                            .AddTag("label")
                            .AddAttribute("for", literalKey)
                            .AddAttribute("class", "form-label")
                            .AddText(title)
                            .AddTag("/label")
                            .AddTag("select")
                            .AddAttribute("name", literalKey)
                            .AddAttribute("id", literalKey)
                            .AddAttribute("class", "form-select mb-3")
                            .AddAttribute("aria-label", literalKey);

                        if (!IsNull(ptrVerticalBraceArea.Execute(option, 0).Result))
                        {
                            var optionTemplate = ptrVerticalBraceContent.Execute(option, 0);
                            var selected = (option[optionTemplate.EndPosition + 2] == '*' ? "selected" : "");
                            _builder
                                .AddTag("option")
                                .AddAttribute("value", optionTemplate.Result)
                                .AddAttribute(selected)
                                .AddText(optionTemplate.Result)
                                .AddTag("/option");
                        }

                        _builder.AddTag("/select");
                    }
                }
            }
        }
        
        return _builder.Build();
    }

    public string GetMarkdown()
    {
        return _markdown;
    }
    
    private bool IsNull(object? value)
    {
        return value == null;
    }

}