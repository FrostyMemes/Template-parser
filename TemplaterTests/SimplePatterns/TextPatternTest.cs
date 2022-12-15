using Templater.Patterns;

namespace TemplaterTests;

[TestClass]
public class TextPatternTest
{
    
    [TestMethod]
    public void TextPatternSuccessefulFinding()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNotNull(patternResult);
    }
    
    
    [TestMethod]
    public void TextPatternUnsuccessefulFinding()
    {
        var testText = "TestText";
        var text = "WTest";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
    
    
    [TestMethod]
    public void TextPatternSuccessefulCheckFindingResult()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.AreEqual("Test",patternResult.Result);
    }
    
    
    [TestMethod]
    public void TextPatternSuccessefulCheckEndPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        
        Assert.AreEqual(4, patternResult.EndPosition);
    }
    
    
    [TestMethod]
    public void TextPatternTryFindWithWrongStartPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 4;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
}