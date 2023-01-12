using System.Text;
using System.Text.RegularExpressions;


namespace Templater.Builder;

public class TemplateParser: TemplatePatterns
{
    private readonly string _markdown;
    private readonly TemplateBuilder builder;

    public TemplateParser(string markdown)
    {
        _markdown = markdown;
        builder = new();
    }

    public string Parse()
    {
        StringBuilder content = new ();
        List<string> keys = new ();
        string tag, type, title, text;
        string literalKey, litrealBody;
        int id;

        builder.Clear();
        builder.AddTag("form");
        
        var literals = _markdown
                .Split(';')
                .Where(literal => !string.IsNullOrWhiteSpace(literal))
                .Select(literal => literal.Trim())
                .ToArray();
        
        foreach (var literal in literals)
        {
            content.Clear();
            
            var literalParts = literal.Split(':');
            literalKey = literalParts[0].Trim();
            litrealBody = literalParts[1].Trim();
            
            content.Append("\n");
            title = literalKey;
            
            if (!IsNull(ptrMarksArea.Execute(litrealBody, 0).Result))
            {
                var markGroup = ptrMarkGroupWords.Matches(litrealBody);
                tag = (markGroup.Count > 1) ? "textarea" : "input";
                
                foreach (Match match in markGroup)
                {
                    text = ptrDuoMarkContent.Execute(match.Value, 0).Result;
                    content.Append((String.IsNullOrEmpty(text)) ? "\n": $"{text}\n");
                }
                
                builder
                    .AddTag("div")
                        .AddAttribute("class", "form-floating mb-3")
                        .AddTag(tag)
                        .AddAttribute("class", "form-control")
                        .AddAttribute("name", literalKey)
                        .AddAttribute("id", literalKey)
                        .AddAttribute("placeholder", title)
                        .AddText((tag == "input")
                            ? $" value={content}>"
                            : $">{content} </{tag}>")
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
                    builder
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

                    foreach(var option in options)
                    {
                        if (!IsNull(ptrVerticalBraceArea.Execute(option, 0).Result))
                        {
                            var optionTemplate = ptrVerticalBraceContent.Execute(option, 0);
                            var selected = (option[optionTemplate.EndPosition + 2] == '*' ? "selected" : string.Empty);
                            builder
                                .AddTag("option")
                                .AddAttribute("value", optionTemplate.Result)
                                .AddAttribute(selected)
                                .AddText(optionTemplate.Result)
                                .AddTag("/option");
                        }

                        builder.AddTag("/select");
                    }
                }
                else
                {
                    id = 1;
                    type = (IsNull(ptrRoundBraceArea.Execute(options[0], 0).Result))  
                        ? "checkbox" 
                        : "radio";
                    
                    foreach(var option in options)
                    {
                        if (!IsNull(ptrEnumTags[type][0].Execute(option, 0).Result))
                        {
                            var temp = ptrEnumTags[type][1].Execute(option, 0);
                            
                            var check = IsNull(temp.Result) 
                                ? string.Empty 
                                : "checked";
                            
                            var optionLabel = option
                                .Substring(temp.EndPosition + 2)
                                .Trim();
                            
                            builder
                                .AddTag("div")
                                .AddAttribute("class", "form-check")
                                    .AddTag("input")
                                    .AddAttribute("class", "form-check-input")
                                    .AddAttribute("type", type)
                                    .AddAttribute("id", $"{id}")
                                    .AddAttribute("name", literalKey)
                                    .AddAttribute(check)
                                    .AddTag("/input")
                                    .AddTag("label")
                                    .AddAttribute("class", "form-check-label")
                                    .AddAttribute("for", $"{id}")
                                    .AddText(optionLabel)
                                    .AddTag("/label")
                                .AddTag("/div");
                        }
                    }
                }
            }
        }

        builder.AddTag("/form");
        return builder.Build();
    }
    
    private bool IsNull(object? value)
    {
        return value == null;
    }
    
    public string GetMarkdown()
    {
        return _markdown;
    }

}