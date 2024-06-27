using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Handler für das Zurücksetzen des Passworts eines Lehrers.
    /// </summary>
    public class ResetPasswordHandler : IRequestHandler<ResetPassword>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="ResetPasswordHandler"/> Klasse.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public ResetPasswordHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Behandelt das Zurücksetzen des Passworts eines Lehrers.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Handle(ResetPassword request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.ReadByIdAsync(request.Email);

            if (teacher == null)
            {
                throw new Exception("Der Lehrer wurde nicht gefunden.");
            }

            teacher.Password = $"{teacher.Surname}.{teacher.FamilyName}";

            await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
