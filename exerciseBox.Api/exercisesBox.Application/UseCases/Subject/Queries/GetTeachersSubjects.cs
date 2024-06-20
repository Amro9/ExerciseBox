using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries;

public class GetTeachersSubjects : IRequest<IEnumerable<SubjectDto>>
{
    public string TeacherId { get; set; }
}
