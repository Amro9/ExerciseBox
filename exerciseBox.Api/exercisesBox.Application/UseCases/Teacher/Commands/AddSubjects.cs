using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    /// <summary>
    /// Befehl zum hinzufügen von Fächern zu einem Lehrer.
    /// </summary>
    public class AddSubjects : IRequest
    {
        public string TeacherId { get; set; }
        public string[] SubjectIds { get; set; }
    }
}
