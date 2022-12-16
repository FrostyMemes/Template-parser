using Templater.Patterns;

namespace TemplaterTests;

[TestClass]
public class TextPatternTest
{
    
    [TestMethod]
    public void SuccessefulFinding()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNotNull(patternResult);
    }
    
    
    [TestMethod]
    public void UnsuccessefulFinding()
    {
        var testText = "TestText";
        var text = "WTest";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
    
    
    [TestMethod]
    public void CorrectFindingResult()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.AreEqual(text,patternResult.Result);
    }
    
    
    [TestMethod]
    public void CorrectEndPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 0;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        
        Assert.AreEqual(4, patternResult.EndPosition);
    }
    
    
    [TestMethod]
    public void TryingFindWithWrongStartPosition()
    {
        var testText = "TestText";
        var text = "Test";
        var posititon = 4;
        
        var testTextPattern = new TextPattern(text);
        var patternResult = testTextPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
}