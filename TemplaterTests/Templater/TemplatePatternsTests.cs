using Templater.Builder;

namespace TemplaterTests.Templater;

[TestClass]

public class TemplatePatternsTests
{

    [TestMethod]
    public void Check_UnsuccessefullFindPtrMarkGroup_Null()
    {
        var testText = @"Test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Check_SuccessefullFindTextPtrMarkGroupWithDuoMarks_ExampleText()
    {
        var testText = @"""ExampleText""_test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.AreEqual(@"""ExampleText""", result.Result);
    }

    [TestMethod]
    public void Check_SuccessefullFindTextPtrMarkGroupWithSingleMarks_ExampleText()
    {
        var testText = @"'ExampleText'_test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.AreEqual(@"'ExampleText'", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrSquareBraceArea_ExampleTextWithSquareBraces()
    {
        var testText = @"[ExampleText]_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceArea.Execute(testText, position);
        Assert.AreEqual(@"[ExampleText]", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrSquareBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrRoundBraceArea_ExampleTextWithRoundBraces()
    {
        var testText = @"(ExampleText)_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceArea.Execute(testText, position);
        Assert.AreEqual(@"(ExampleText)", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrRoundBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrVerticalBraceArea_ExampleTextWithVerticalBraces()
    {
        var testText = @"|ExampleText|_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceArea.Execute(testText, position);
        Assert.AreEqual(@"|ExampleText|", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrVerticalBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrFigureBraceArea_ExampleTextWithFigureBraces()
    {
        var testText = @"{ExampleText}_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceArea.Execute(testText, position);
        Assert.AreEqual(@"{ExampleText}", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindPtrFigureBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
}