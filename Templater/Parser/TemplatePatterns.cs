using System.Text.RegularExpressions;
using Templater.Patterns;
using Templater.Patterns.Combinators;

namespace Templater.Builder;

public class TemplatePatterns
{
    static readonly PatternResult nullValue = new (null, -1);
    
    protected static readonly RegexPattern ptrMarkGroupWords = new (
        new Regex(@"""([^""\\]*(\\.[^""\\]*)*)""|\'([^\'\\]*(\\.[^\'\\]*)*)\'"));
    
    protected static readonly AlternativePattern ptrSquareBraceArea = new (
        new RegexPattern(
            new Regex(@"\[(.*)\]")), nullValue);

    protected static readonly AlternativePattern ptrRoundBraceArea = new (
        new RegexPattern(
            new Regex(@"\((.*)\)")), nullValue);

    protected static readonly AlternativePattern ptrVerticalBraceArea = new (
        new RegexPattern(
            new Regex(@"\|(.*)\|")), nullValue);

    protected static readonly AlternativePattern ptrFigureBraceArea = new (
        new RegexPattern(
            new Regex(@"\{(.*)\}")), nullValue);
    
    protected static readonly AlternativePattern ptrSingleMarkArea = new (
        new RegexPattern(
            new Regex(@"\'(.*)\'")), nullValue);

    protected static readonly AlternativePattern ptrRoundBraceContent = new (
        new RegexPattern(
            new Regex(@"(?<=\()(.*?)(?=\))")), nullValue);

    protected static readonly AlternativePattern ptrSquareBraceContent = new (
        new RegexPattern(
            new Regex(@"(?<=\[)(.*?)(?=\])")), nullValue);

    protected static readonly AlternativePattern ptrVerticalBraceContent = new (
        new RegexPattern(
            new Regex(@"(?<=\|)(.*?)(?=\|)")), nullValue);

    protected static readonly AlternativePattern ptrFigureBraceContent = new (
        new RegexPattern(
            new Regex(@"(?<=\{)(.*?)(?=\})")), nullValue);

    protected static readonly AlternativePattern ptrSingleMarkContent = new (
        new RegexPattern(
            new Regex(@"(?<=\')(.*?)(?=\')")), nullValue);

    protected static readonly AlternativePattern ptrDuoarkContent = new (
        new RegexPattern(
            new Regex(@"(?<=\"")(.*?)(?=\"")")), nullValue);
}