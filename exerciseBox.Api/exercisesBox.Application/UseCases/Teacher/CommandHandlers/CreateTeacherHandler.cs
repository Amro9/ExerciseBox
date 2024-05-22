using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacher>
    {
        public Task Handle(CreateTeacher request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
