using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Commands
{
    public class RemoveSubject : IRequest
    {
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }
    }
}
