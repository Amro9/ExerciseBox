using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    public class GetAllSubjectsHandler : IRequestHandler<GetAllSubjects, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;
        public GetAllSubjectsHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjects request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectRepository.ReadAsync();
            return subjects.MaptToSubjectDto();
        }
    }
}
