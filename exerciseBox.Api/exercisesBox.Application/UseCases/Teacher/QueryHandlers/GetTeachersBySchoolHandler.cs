using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers
{
    /// <summary>
    /// Query-Handler zur Abfrage von Lehrern anhand der Schul-ID.
    /// </summary>
    public class GetTeachersBySchoolHandler : IRequestHandler<GetTeachersBySchool, IEnumerable<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeachersBySchoolHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet die Anfrage zum Abrufen von Lehrern anhand der Schul-ID.
        /// </summary>
        /// <param name="request">Die Anfrage mit der Schul-ID.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Eine Liste von Lehrer-Datenübertragungsobjekten (DTOs).</returns>
        public async Task<IEnumerable<TeacherDto>> Handle(GetTeachersBySchool request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherRepository.ReadBySchoolIdAsync(request.SchoolId);
            return teachers.MapToTeacherDto();
        }
    }
}
