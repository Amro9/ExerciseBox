using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.CommandHandlers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacher, Domain.Entities.Teachers>
    {
        private readonly ITeacherRepository _teacherRepository;

        public CreateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Domain.Entities.Teachers> Handle(CreateTeacher request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.Create(request.Teacher);
            return teacher;
        }
    }
}
