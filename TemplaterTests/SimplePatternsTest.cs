using Templater.Patterns;

namespace TemplaterTests;

[TestClass]
public class SimplePatternsTest
{
    [TestMethod]
    public void TextPatternSuccesseful()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNotNull(patternResult);
    }
    
    [TestMethod]
    public void TextPatternSuccessefulCheckEndPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        
        var expectation = 4;
        
        Assert.AreEqual(expectation, patternResult.EndPosition);
    }
    
    [TestMethod]
    public void TextPatternUnsuccesseful()
    {
        var testText = "TestText";
        var text = "Untest";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
    
    [TestMethod]
    public void TextPatternTryFindWithWrongStartPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 1;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
    
    
    // [TestMethod]
    // public void RegexPatternSuccessefulFinding()
    // {
    //     
    // }
    //
    // [TestMethod]
    // public void RegexPatternUnsuccessefulFinding()
    // {
    //     
    // }
}