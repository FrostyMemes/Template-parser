using Templater.Builder;

namespace TemplaterTests.Templater;

[TestClass]

public class TemplatePatternsTests
{

    [TestMethod]
    public void Check_UnsuccessefullFindingPtrMarkGroup_Null()
    {
        var testText = @"Test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Check_SuccessefullFindingTextPtrMarkGroupWithDuoMarks_ExampleText()
    {
        var testText = @"""ExampleText""_test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.AreEqual(@"""ExampleText""", result.Result);
    }

    [TestMethod]
    public void Check_SuccessefullFindingTextPtrMarkGroupWithSingleMarks_ExampleText()
    {
        var testText = @"'ExampleText'_test";
        var position = 0;
        var result = TemplatePatterns.ptrMarkGroupWords.Execute(testText, position);
        Assert.AreEqual(@"'ExampleText'", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrSquareBraceArea_ExampleTextWithSquareBraces()
    {
        var testText = @"[ExampleText]_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceArea.Execute(testText, position);
        Assert.AreEqual(@"[ExampleText]", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrSquareBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrRoundBraceArea_ExampleTextWithRoundBraces()
    {
        var testText = @"(ExampleText)_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceArea.Execute(testText, position);
        Assert.AreEqual(@"(ExampleText)", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrRoundBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrVerticalBraceArea_ExampleTextWithVerticalBraces()
    {
        var testText = @"|ExampleText|_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceArea.Execute(testText, position);
        Assert.AreEqual(@"|ExampleText|", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrVerticalBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrFigureBraceArea_ExampleTextWithFigureBraces()
    {
        var testText = @"{ExampleText}_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceArea.Execute(testText, position);
        Assert.AreEqual(@"{ExampleText}", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrFigureBraceArea_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceArea.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrSquareBraceContent_ExampleText()
    {
        var testText = @"[ExampleText]_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceContent.Execute(testText, position);
        Assert.AreEqual(@"ExampleText", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrSquareBraceContent_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrSquareBraceContent.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrRoundBraceConntent_ExampleText()
    {
        var testText = @"(ExampleText)_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceContent.Execute(testText, position);
        Assert.AreEqual(@"ExampleText", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrRoundBraceContent_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrRoundBraceContent.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrVerticalBraceContent_ExampleText()
    {
        var testText = @"|ExampleText|_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceContent.Execute(testText, position);
        Assert.AreEqual(@"ExampleText", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrVerticalBraceContent_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrVerticalBraceContent.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrFigureBraceContent_ExampleText()
    {
        var testText = @"{ExampleText}_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceContent.Execute(testText, position);
        Assert.AreEqual(@"ExampleText", result.Result);
    }
    
    [TestMethod]
    public void Check_SuccessefullFindingPtrFigureBraceContent_Null()
    {
        var testText = @"ExampleText_test";
        var position = 0;
        var result = TemplatePatterns.ptrFigureBraceContent.Execute(testText, position);
        Assert.IsNull(result.Result);
    }
}