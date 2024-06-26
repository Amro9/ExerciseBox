using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teachers.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Teachers.QueryHandlers
{
    /// <summary>
    /// Query-Handler zur Abfrage aller Lehrer.
    /// </summary>
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeachers, IEnumerable<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den GetAllTeachersHandler.
        /// </summary>
        /// <param name="teacherRepository">Das Repository, das für den Zugriff auf Lehrerdaten verwendet wird.</param>
        public GetAllTeachersHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet die Anfrage zum Abrufen aller Lehrer.
        /// </summary>
        /// <param name="request">Die Anfrage zum Abrufen aller Lehrer (keine spezifischen Parameter).</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Eine Liste von Lehrer-Datenübertragungsobjekten (DTOs).</returns>
        public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachers request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherRepository.ReadAsync();
            return teachers.MapToTeacherDto();
        }
    }
}
