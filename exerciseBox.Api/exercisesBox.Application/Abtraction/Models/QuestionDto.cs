using exerciseBox.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Fragen.
    /// </summary>
    public class QuestionDto
    {
        /// <summary>
        /// Ruft die ID der Frage ab oder legt diese fest.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ruft den Autor der Frage ab oder legt diesen fest.
        /// </summary>
        [Required(ErrorMessage = "Der Autor darf nicht null sein.")]
        public string Author { get; set; }

        /// <summary>
        /// Ruft den Text der Frage ab oder legt diesen fest.
        /// </summary>
        [Required(ErrorMessage = "Der Text der Frage darf nicht null sein.")]
        public string QuestionText { get; set; }

        /// <summary>
        /// Ruft die Antwort auf die Frage ab oder legt diese fest.
        /// </summary>
        [Required(ErrorMessage = "Die Antwort der Frage darf nicht null sein.")]
        public string Answer { get; set; }

        /// <summary>
        /// Ruft die Schulstufe der Frage ab oder legt diese fest.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Die Schulstufe muss größer als 0 sein.")]
        public int SchoolLevel { get; set; }

        /// <summary>
        /// Ruft den Schwierigkeitsgrad der Frage ab oder legt diesen fest.
        /// </summary>
        //public string DifficultyLevel { get; set; }

        public DifficultyLevelDto DifficultyLevelDto { get; set; }

        public int SchoolType { get; set; }
        public string? SchoolBranch { get; set; }

        /// <summary>
        /// Ruft das Thema der Frage ab oder legt dieses fest.
        /// </summary>
        [Required(ErrorMessage = "Das Thema darf nicht null sein.")]
        public string Topic { get; set; }


        public bool QuestionIsPrivate { get; set; }

        /// <summary>
        /// Konstruktor für das QuestionDto, der eine neue ID generiert.
        /// </summary>
        public QuestionDto()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Konvertiert ein Questions-Objekt implizit in ein QuestionDto-Objekt.
        /// </summary>
        public static implicit operator QuestionDto(Questions question)
        {
            return new QuestionDto
            {
                Id = Guid.Parse(question.Id),
                QuestionText = question.QuestionText,
                Answer = question.Answer,
                SchoolLevel = question.SchoolLevel,
                Topic = question.Topic,
                QuestionIsPrivate = question.QuestionIsPrivate,
                Author = question.Author,
                SchoolBranch = question.SchoolBranch,
                SchoolType = question.SchoolType,
                DifficultyLevelDto = question.DifficultyLevelNavigation
            };
        }

        /// <summary>
        /// Konvertiert ein QuestionDto-Objekt implizit in ein Questions-Objekt.
        /// </summary>
        public static implicit operator Questions(QuestionDto question)
        {
            return new Questions
            {
                Id = question.Id.ToString(),
                QuestionText = question.QuestionText,
                Answer = question.Answer,
                DifficultyLevel = question.DifficultyLevelDto.Id,
                SchoolLevel = question.SchoolLevel,
                Topic = question.Topic,
                QuestionIsPrivate = question.QuestionIsPrivate,
                Author = question.Author,
                SchoolBranch = question.SchoolBranch,
                SchoolType = question.SchoolType
                
            };
        }
    }
}
