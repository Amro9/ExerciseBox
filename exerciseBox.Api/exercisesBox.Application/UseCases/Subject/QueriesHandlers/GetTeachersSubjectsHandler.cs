using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    /// <summary>
    /// Query-Handler zur Abfrage der Fächer eines Lehrers.
    /// </summary>
    internal class GetTeachersSubjectsHandler : IRequestHandler<GetTeachersSubjects, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;

        /// <summary>
        /// Konstruktor für den GetTeachersSubjectsHandler.
        /// </summary>
        /// <param name="subjectRepository">Das Repository, das für die Datenbankoperationen mit Fächern verwendet wird.</param>
        public GetTeachersSubjectsHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        /// <summary>
        /// Verarbeitet den Query zur Abfrage der Fächer eines Lehrers.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage der Fächer eines Lehrers.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Eine Liste von SubjectDto-Objekten, die die abgefragten Fächer darstellen.</returns>
        public async Task<IEnumerable<SubjectDto>> Handle(GetTeachersSubjects request, CancellationToken cancellationToken)
        {
            // Fächer des Lehrers abfragen
            var subjects = await _subjectRepository.GetSubjectsByTeacherId(request.TeacherId);
            return subjects.MapToSubjectDto();
        }
    }
}
