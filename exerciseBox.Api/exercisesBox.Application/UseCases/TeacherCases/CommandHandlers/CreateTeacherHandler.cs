using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.TeacherCases.Commands;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.TeacherCases.CommandHandlers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacher, Teachers>
    {
        private readonly ITeacherRepository _teacherRepository;

        public CreateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teachers> Handle(CreateTeacher request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.Create(request.Teacher);
            return teacher;
        }
    }
}
