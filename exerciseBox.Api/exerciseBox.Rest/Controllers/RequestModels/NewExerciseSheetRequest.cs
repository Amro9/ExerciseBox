using exerciseBox.Application.Abtraction.Models;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage zum Erstellen eines neuen Übungsblatts.
    /// </summary>
    public class NewExerciseSheetRequest
    {
        /// <summary>
        /// Das DTO für das Übungsblatt.
        /// </summary>
        public ExerciseSheetDto ExerciseSheet { get; set; }

        /// <summary>
        /// Die IDs der Fragen, die dem Übungsblatt hinzugefügt werden sollen.
        /// </summary>
        public string[] QuestionIds { get; set; }

        /// <summary>
        /// Gibt an, ob die Antworten auf die Fragen mitgeliefert werden sollen.
        /// </summary>
        public bool WithAnswers { get; set; }   
    }
}
