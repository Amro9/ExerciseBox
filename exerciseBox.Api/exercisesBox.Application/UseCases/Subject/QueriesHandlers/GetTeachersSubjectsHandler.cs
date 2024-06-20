using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers;

internal class GetTeachersSubjectsHandler : IRequestHandler<GetTeachersSubjects, IEnumerable<SubjectDto>>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetTeachersSubjectsHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<IEnumerable<SubjectDto>> Handle(GetTeachersSubjects request, CancellationToken cancellationToken)
    {
        var subjects = await _subjectRepository.GetSubjectsByTeacherId(request.TeacherId);
        return subjects.MaptToSubjectDto();
    }
}
