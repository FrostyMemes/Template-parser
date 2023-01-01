using System.Text;

namespace Templater.Builder;

public class TemplateBuilder
{
    private readonly StringBuilder template;

    public TemplateBuilder() => template = new StringBuilder(100);
    public TemplateBuilder(string head) => template = new StringBuilder(head, 100);
    public string Build() => template.ToString();
    
    public TemplateBuilder AddTag(string tag)
    {
        template.Append($"<{tag}>\n");
        return this;
    }

    public TemplateBuilder AddText(string text)
    {
        template.Append($"{text}\n");
        return this;
    }

    public TemplateBuilder AddAttribute(string name, string value)
    {
        var pos = template.ToString().LastIndexOf('>');
        template.Insert(pos, $" {name}={value} ");
        return this;
    }

    public TemplateBuilder AddAttributes(ICollection<KeyValuePair<string, string>> attributes)
    {
        var pos = template.ToString().LastIndexOf('>');
        var attribute = "";

        foreach (var attr in attributes)
        {
            attribute = $" {attr.Key}={attr.Value} ";
            template.Insert(pos, attribute);
            pos += attribute.Length;
        }
        return this;
    }

    public TemplateBuilder Clear()
    {
        template.Clear();
        return this;
    }
}