using exerciseBox.Application.Services.Models;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für Suchparameter für Fragen.
    /// </summary>
    public class QuestionSearchParamsRequest
    {
        /// <summary>
        /// Der Typ der Schule.
        /// </summary>
        public int? SchoolType { get; set; }

        /// <summary>
        /// Der Zweig der Schule.
        /// </summary>
        public string? SchoolBranch { get; set; }

        /// <summary>
        /// Das Level der Schule.
        /// </summary>
        public int? SchoolLevel { get; set; }

        /// <summary>
        /// Das Fach der Frage.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Das Thema der Frage.
        /// </summary>
        public string? Topic { get; set; }

        /// <summary>
        /// Das Schwierigkeitslevel der Frage.
        /// </summary>
        public string? DifficultyLevel { get; set; }

        /// <summary>
        /// Implizite Konvertierung von <see cref="QuestionSearchParamsRequest"/> zu <see cref="QuestionSearchParams"/>.
        /// </summary>
        /// <param name="request">Das <see cref="QuestionSearchParamsRequest"/> Objekt, das konvertiert werden soll.</param>
        /// <returns>Ein <see cref="QuestionSearchParams"/> Objekt mit den Suchparametern aus <paramref name="request"/>.</returns>
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
