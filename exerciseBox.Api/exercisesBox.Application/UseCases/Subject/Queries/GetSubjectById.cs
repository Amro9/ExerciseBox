using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    public class GetSubjectById: IRequest<SubjectDto>
    {
        public string Id { get; set; }
        public GetSubjectById(string id)
        {
            Id = id;
        }
    }
}
