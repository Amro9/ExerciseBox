using exerciseBox.Application.Services;
using exerciseBox.Domain.Entities;
using QuestPDF.Infrastructure;

namespace exerciseBox.Application.Tests;

[TestClass]
public class ExerciseSheetGeneratorTests
{
    [TestMethod]
    public void Generate_ShouldGenerateExerciseSheet()
    {
        #region Arrange
        var exerciseSheet = new ExerciseSheets
        {
            Tilte = "Exercise Sheet 1",
            SubjectPlaceHolder = true
        };

        var questions = new List<Questions>
            {
                new Questions { QuestionText = "Question 1" },
                new Questions { QuestionText = "Question 2" },
                new Questions { QuestionText = "Question 3" }
            };

        var generator = new ExerciseSheetGenerator();
        #endregion

        QuestPDF.Settings.License = LicenseType.Community;

        #region Act
        var result = generator.Generate(exerciseSheet, questions);
        #endregion

        #region Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(byte[]));
        Assert.IsTrue(result.Length > 0);
        #endregion
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void Generate_ShouldThrowException_WhenQuestionsIsNull()
    {
        #region Arrange
        var exerciseSheet = new ExerciseSheets
        {
            Tilte = "Exercise Sheet 1",
            NamePlaceHolder = true
        };

        List<Questions> questions = null;

        var generator = new ExerciseSheetGenerator();
        #endregion

        #region Act
        var result = generator.Generate(exerciseSheet, questions);
        #endregion
    }
}
