using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePassword>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UpdatePasswordHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task Handle(UpdatePassword request, CancellationToken cancellationToken)
        {
            var teacher = await  _teacherRepository.ReadByEmailAsync(request.Email);
            teacher.Password = request.Password;
            await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
