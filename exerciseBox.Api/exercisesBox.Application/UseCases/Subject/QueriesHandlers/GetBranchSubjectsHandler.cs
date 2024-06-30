using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    public class GetBranchSubjectsHandler : IRequestHandler<GetBranchSubjects, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetBranchSubjectsHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetBranchSubjects request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectRepository.GetSubjectsBySchoolBranchId(request.BranchId);
            return subjects.MapToSubjectDto();
        }
    }
}
