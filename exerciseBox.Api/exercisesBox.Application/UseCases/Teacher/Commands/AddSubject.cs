using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    /// <summary>
    /// Befehl zum hinzufügen von Fächern zu einem Lehrer.
    /// </summary>
    public class AddSubject : IRequest
    {
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }
    }
}
