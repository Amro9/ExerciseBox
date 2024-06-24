using exerciseBox.Application.Services.Models;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class QuestionSearchParamsRequest
    {
        public int? SchoolType { get; set; }
        public string? SchoolBranch { get; set; }
        public int? SchoolLevel { get; set; }
        public string? Subject { get; set; }
        public string? Topic { get; set; }
        public string? DifficultyLevel { get; set; }

        public static implicit operator QuestionSearchParams(QuestionSearchParamsRequest request)
        {
            return new QuestionSearchParams
            {
                SchoolType = request.SchoolType,
                SchoolBranch = request.SchoolBranch,
                SchoolLevel = request.SchoolLevel,
                Subject = request.Subject,
                Topic = request.Topic,
                DifficultyLevel = request.DifficultyLevel
            };
        }
      
    }
}
