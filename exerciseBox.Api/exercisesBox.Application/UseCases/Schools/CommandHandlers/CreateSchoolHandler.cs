using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.CommandHandlers
{
    /// <summary>
    /// Handler für den Befehl zur Erstellung einer neuen Schule.
    /// </summary>
    public class CreateSchoolHandler : IRequestHandler<CreateSchool, SchoolDto>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateSchoolHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Behandelt den Befehl zur Erstellung einer neuen Schule.
        /// </summary>
        /// <param name="request">Der Befehl zur Erstellung der Schule.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchanforderung.</param>
        /// <returns>Die erstellte Schule als Data Transfer Object (DTO).</returns>
        public async Task<SchoolDto> Handle(CreateSchool request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.CreateAsync(request.School);
            return school;
        }
    }
}
