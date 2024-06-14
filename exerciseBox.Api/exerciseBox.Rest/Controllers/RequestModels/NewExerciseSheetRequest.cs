using exerciseBox.Application.Abtraction.Models;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class NewExerciseSheetRequest
    {
        public ExerciseSheetDto ExerciseSheet { get; set; }
        public string[] QuestionIds { get; set; }
    }
}
