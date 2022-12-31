using Templater.Patterns;
using Templater.Patterns.Combinators;

namespace TemplaterTests.CombinatorPatterns;

[TestClass]
public class AnyPatternTest
{
    [TestMethod]
    public void SuccessefulFindingWithTwoPatternsWhenSuccessefulFirstPattern()
    {
        var testText = "TestText";
        var text1 = "Test";
        var text2 = "West";
        var posititon = 0;

        var textPatternSuccesseful = new TextPattern(text1);
        var textPatternUnsuccesseful = new TextPattern(text2);
        var testAnyPattern = new AnyPattern(textPatternSuccesseful, textPatternUnsuccesseful);

        var patternResult = testAnyPattern.Execute(testText, posititon);

        Assert.IsNotNull(patternResult);
    }

    [TestMethod]
    public void SuccessefulFindingWithTwoPatternsWhenSuccessefulSecondPattern()
    {
        var testText = "TestText";
        var text1 = "Test";
        var text2 = "West";
        var posititon = 0;

        var textPatternSuccesseful = new TextPattern(text1);
        var textPatternUnsuccesseful = new TextPattern(text2);
        var testAnyPattern = new AnyPattern(textPatternUnsuccesseful, textPatternSuccesseful);

        var patternResult = testAnyPattern.Execute(testText, posititon);

        Assert.IsNotNull(patternResult);
    }

    [TestMethod]
    public void CorrectFindingResult()
    {
        var testText = "TestText";
        var text1 = "Test";
        var text2 = "West";
        var posititon = 0;

        var textPatternSuccesseful = new TextPattern(text1);
        var textPatternUnsuccesseful = new TextPattern(text2);
        var testAnyPattern = new AnyPattern(textPatternUnsuccesseful, textPatternSuccesseful);

        var patternResult = testAnyPattern.Execute(testText, posititon);

        Assert.AreEqual(text1, patternResult.Result);
    }
}