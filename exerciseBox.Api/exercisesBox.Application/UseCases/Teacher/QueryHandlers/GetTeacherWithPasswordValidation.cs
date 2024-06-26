using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers
{
    /// <summary>
    /// Query-Handler zur Validierung eines Lehrers anhand von E-Mail und Passwort.
    /// </summary>
    public class GetTeacherWithPasswordValidationHandler : IRequestHandler<GetTeacherWithPasswordValidation, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherWithPasswordValidationHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
        }

        /// <summary>
        /// Verarbeitet die Anfrage zum Abrufen eines Lehrers anhand von E-Mail und Validierung des Passworts.
        /// </summary>
        /// <param name="request">Die Anfrage mit E-Mail und Passwort des Lehrers.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Ein Lehrer-Datenübertragungsobjekt (DTO), wenn erfolgreich; andernfalls null.</returns>
        public async Task<TeacherDto> Handle(GetTeacherWithPasswordValidation request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.ReadByEmailAsync(request.Email);
            if (teacher == null)
            {
                return null;
            }

            if (!request.Password.VerifyPassword(teacher.Password))
            {
                throw new UnauthorizedAccessException("Ungültiges Passwort");
            }

            return teacher;
        }
    }
}
