namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage zur Erstellung einer Frage.
    /// </summary>
    public class QuestionRequest
    {
        /// <summary>
        /// Der Text der Frage.
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Die Antwort zur Frage.
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Das Schullevel der Frage.
        /// </summary>
        public int SchoolLevel { get; set; }

        /// <summary>
        /// Das Schwierigkeitslevel der Frage.
        /// </summary>
        public string DifficultyLevel { get; set; }

        /// <summary>
        /// Das Fach der Frage.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Das Thema der Frage.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Gibt an, ob die Frage nur für den Ersteller sichtbar sein soll.
        /// </summary>
        public bool QuestionOnlyForMe { get; set; }
    }
}
