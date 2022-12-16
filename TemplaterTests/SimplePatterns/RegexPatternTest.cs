using Templater.Patterns;

namespace TemplaterTests;

[TestClass]
public class RegexPatternTest
{
    [TestMethod]
    public void SuccessefulFinding()
    {
        var testText = "expamletTestText";
        var posititon = 0;

        var testRegex = new Regex(@"[T]\w+");
        var testRegexPattern = new RegexPattern(testRegex);
        var patternResult = testRegexPattern.Execute(testText, posititon);
        Assert.IsNotNull(patternResult);
    }
    
    
    [TestMethod]
    public void UnsuccessefulFinding()
    {
        var testText = "WestWext";
        var posititon = 0;
    
        var testRegex = new Regex(@"[T]\w+");
        var testRegexPattern = new RegexPattern(testRegex);
        var patternResult = testRegexPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
    
    
    [TestMethod]
    public void CorrectFindingResult()
    {
        var testText = "exampleTestText";
        var posititon = 0;
        
        var testRegex = new Regex(@"[T]\w+");
        var testRegexPattern = new RegexPattern(testRegex);
        var patternResult = testRegexPattern.Execute(testText, posititon);
        Assert.AreEqual("TestText",patternResult.Result);
    }
    
    
    [TestMethod]
    public void CorrectEndPosition()
    {
        var testText = "TestTest";
        var posititon = 0;
    
        var testRegex = new Regex(@"[T]\w+");
        var testRegexPattern = new RegexPattern(testRegex);
        var patternResult = testRegexPattern.Execute(testText, posititon);
        
        Assert.AreEqual(8, patternResult.EndPosition);
    }
    
    
    [TestMethod]
    public void TryingFindWithWrongStartPosition()
    {
        var testText = "TestTest";
        var posititon = 7;
        
        var testRegex = new Regex(@"[T]\w+");
        var testRegexPattern = new RegexPattern(testRegex);
        var patternResult = testRegexPattern.Execute(testText, posititon);
        Assert.IsNull(patternResult);
    }
}