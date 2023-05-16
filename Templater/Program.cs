using System.Text.RegularExpressions;
using Templater.Patterns;
using Templater.Patterns.Combinators;

PatternResult alt = new PatternResult(null, -1);

RegexPattern pattern = new RegexPattern(new Regex(@"\[(.*)\]"));

var a = pattern.Execute("", 1);

Console.Write("");
