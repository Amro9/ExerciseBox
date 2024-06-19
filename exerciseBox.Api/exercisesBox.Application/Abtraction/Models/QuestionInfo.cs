//using exerciseBox.Domain.Entities;

//namespace exerciseBox.Application.Abtraction.Models
//{
//    /// <summary>
//    /// Datenübertragungsobjekt für Fragen.
//    /// </summary>
//    public class QuestionInfo
//    {
//        /// <summary>
//        /// Ruft die ID der Frage ab oder legt diese fest.
//        /// </summary>
//        public Guid Id { get; set; }

//        /// <summary>
//        /// Ruft den Text der Frage ab oder legt diesen fest.
//        /// </summary>
//        public string QuestionText { get; set; }

//        /// <summary>
//        /// Ruft die Antwort auf die Frage ab oder legt diese fest.
//        /// </summary>
//        public string Answer { get; set; }

//        /// <summary>
//        /// Ruft die Schulstufe der Frage ab oder legt diese fest.
//        /// </summary>
//        public int SchoolLevel { get; set; }


//        /// <summary>
//        /// Ruft einen Wert ab, der angibt, ob die Frage privat ist, oder legt diesen fest.
//        /// </summary>
//        public bool QuestionIsPrivate { get; set; }

//        /// <summary>
//        /// Konstruktor für das QuestionDto, der eine neue ID generiert.
//        /// </summary>
//        public TopicDto TopicNavigation { get; set; }
//        public SubjectDto SubjectNavigation { get; set; }
//        public DifficultyLevelDto DifficultyLevelNavigation { get; set; }
//        public TeacherDto AuthorNavigation { get; set; }

//        public QuestionInfo()
//        {
//            Id = Guid.NewGuid();
//        }

//        /// <summary>
//        /// Konvertiert ein Questions-Objekt implizit in ein QuestionDto-Objekt.
//        /// </summary>
//        public static implicit operator QuestionInfo(Questions question)
//        {
//            return new QuestionInfo
//            {
//                Id = Guid.Parse(question.Id),
//                QuestionText = question.QuestionText,
//                Answer = question.Answer,
//                SchoolLevel = question.SchoolLevel,
//                QuestionIsPrivate = question.QuestionIsPrivate,
//                AuthorNavigation = question.AuthorNavigation,
//                DifficultyLevelNavigation = question.DifficultyLevelNavigation,
//                SubjectNavigation = question.Subject,
//                TopicNavigation = question.TopicNavigation

//            };
//        }

//        /// <summary>
//        /// Konvertiert ein QuestionDto-Objekt implizit in ein Questions-Objekt.
//        /// </summary>
//        public static implicit operator Questions(QuestionInfo question)
//        {
//            return new Questions
//            {
//                Id = question.Id.ToString(),
//                QuestionText = question.QuestionText,
//                Answer = question.Answer,
//                DifficultyLevel = question.DifficultyLevel,
//                SchoolLevel = question.SchoolLevel,
//                Topic = question.Topic,
//                QuestionIsPrivate = question.QuestionIsPrivate,
//                Author = question.Author
//            };
//        }
//    }
//}
