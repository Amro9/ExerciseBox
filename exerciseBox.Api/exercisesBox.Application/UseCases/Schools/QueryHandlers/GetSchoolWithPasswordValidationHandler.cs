using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers
{
    /// <summary>
    /// Handler zur Validierung von Schulen anhand der E-Mail-Adresse und des Passworts.
    /// </summary>
    public class GetSchoolWithPasswordValidationHandler : IRequestHandler<GetSchoolWithPasswordValidation, SchoolDto>
    {
        private readonly ISchoolRepository _schoolRepository;

        /// <summary>
        /// Konstruktor für den GetSchoolWithPasswordValidationHandler.
        /// </summary>
        /// <param name="schoolRepository">Das Repository, das für die Datenbankoperationen mit Schulen verwendet wird.</param>
        public GetSchoolWithPasswordValidationHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        /// <summary>
        /// Verarbeitet den Query zur Validierung einer Schule anhand der E-Mail-Adresse und des Passworts.
        /// </summary>
        /// <param name="request">Der Query zur Validierung der Schule.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Das SchoolDto-Objekt der validierten Schule oder null, falls die Schule nicht gefunden wurde oder das Passwort ungültig ist.</returns>
        public async Task<SchoolDto> Handle(GetSchoolWithPasswordValidation request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.ReadByEmail(request.Email);

            if (school == null)
            {
                return null;
            }

            if (!request.Password.VerifyPassword(school.Password))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            return school;
        }
    }
}
