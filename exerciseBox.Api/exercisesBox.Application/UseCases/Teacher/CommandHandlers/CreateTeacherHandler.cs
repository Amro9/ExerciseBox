using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teachers.Commands;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.CommandHandlers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacher, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        public CreateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherDto> Handle(CreateTeacher request, CancellationToken cancellationToken)
        {
            request.Teacher.Password = request.Teacher.Password.HashPassword();

            var teacher = await _teacherRepository.Create(request.Teacher);
            return teacher;
        }
    }
}
