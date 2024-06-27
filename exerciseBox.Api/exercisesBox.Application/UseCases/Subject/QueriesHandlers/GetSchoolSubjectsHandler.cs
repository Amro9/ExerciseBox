using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;
using System.Net.NetworkInformation;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    /// <summary>
    /// Ein Handler für die Anfrage, um alle Schulfächer zu erhalten.
    /// </summary>
    public class GetSchoolSubjectsHandler : IRequestHandler<GetSchoolSubjects, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="GetSchoolSubjectsHandler"/> Klasse.
        /// </summary>
        /// <param name="subjectRepository"></param>
        public GetSchoolSubjectsHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        /// <summary>
        /// Behandelt die Anfrage, um alle Schulfächer zu erhalten.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SubjectDto>> Handle(GetSchoolSubjects request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectRepository.GetSubjectsBySchoolId(request.SchoolId);
            return subjects.MapToSubjectDto();
        }
    }
}
