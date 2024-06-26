using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers
{
    /// <summary>
    /// Query-Handler zur Abfrage eines Lehrers anhand der E-Mail-Adresse.
    /// </summary>
    public class GetTeacherByEmailHandler : IRequestHandler<GetTeacherByEmail, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den GetTeacherByEmailHandler.
        /// </summary>
        /// <param name="teacherRepository">Das Repository, das für den Zugriff auf Lehrerdaten verwendet wird.</param>
        public GetTeacherByEmailHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet die Anfrage zum Abrufen eines Lehrers anhand der E-Mail-Adresse.
        /// </summary>
        /// <param name="request">Die Anfrage mit der E-Mail-Adresse des Lehrers.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Ein Lehrer-Datenübertragungsobjekt (DTO) oder null, wenn kein Lehrer gefunden wurde.</returns>
        public async Task<TeacherDto> Handle(GetTeacherByEmail request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.ReadByEmailAsync(request.Email);
            return teacher;
        }
    }
}
