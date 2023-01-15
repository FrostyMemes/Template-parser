using Templater.Builder;

var mParser = new TemplateParser(@"test: '1', '2';");
Console.Write(mParser.Parse());