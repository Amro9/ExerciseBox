using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries
{
    /// <summary>
    /// Abfrage, um die Schule eines Lehrers zu erhalten.
    /// </summary>
    public class GetBrancheOfTeacher : IRequest<SchoolBrancheDto>
    {
        public string TeacherId { get; set; }
    }
}
