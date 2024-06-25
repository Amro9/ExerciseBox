using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries;

public class GetSchoolWithPasswordValidation : IRequest<SchoolDto>
{
    public string SchoolId { get; set; }
    public string Password { get; set; }
}
