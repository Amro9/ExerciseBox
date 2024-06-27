using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    /// <summary>
    /// Eine Anfrage, um alle Schulfächer zu erhalten.
    /// </summary>
    public class GetSchoolSubjects : IRequest<IEnumerable<SubjectDto>>
    {
        public string SchoolId { get; set; }
    }
}
