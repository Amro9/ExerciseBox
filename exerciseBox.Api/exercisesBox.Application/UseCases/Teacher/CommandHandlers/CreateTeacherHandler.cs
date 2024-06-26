using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teachers.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.CommandHandlers
{
    /// <summary>
    /// Command-Handler zur Behandlung des Befehls zur Erstellung eines neuen Lehrers.
    /// </summary>
    public class CreateTeacherHandler : IRequestHandler<CreateTeacher, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den CreateTeacherHandler.
        /// </summary>
        /// <param name="teacherRepository">Das Repository, das für die Datenbankoperationen mit Lehrern verwendet wird.</param>
        public CreateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet den Befehl zur Erstellung eines neuen Lehrers.
        /// </summary>
        /// <param name="request">Der Befehl zur Erstellung eines neuen Lehrers.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Das erstellte Lehrer-Datenübertragungsobjekt (DTO).</returns>
        public async Task<TeacherDto> Handle(CreateTeacher request, CancellationToken cancellationToken)
        {
            // Passwort des Lehrers hashen, bevor er in die Datenbank gespeichert wird
            request.Teacher.Password = request.Teacher.Password.HashPassword();

            // Lehrer in der Datenbank erstellen und zurückgeben
            var createdTeacher = await _teacherRepository.CreateAsync(request.Teacher);
            return createdTeacher;
        }
    }
}
