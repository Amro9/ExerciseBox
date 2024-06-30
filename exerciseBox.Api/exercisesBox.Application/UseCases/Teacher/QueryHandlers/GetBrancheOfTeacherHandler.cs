using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers
{
    /// <summary>
    /// Handler für die Abfrage, um die Schule eines Lehrers zu erhalten.
    /// </summary>
    public class GetBrancheOfTeacherHandler : IRequestHandler<GetBrancheOfTeacher, SchoolBrancheDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Erstellt eine neue Instanz des Handlers.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public GetBrancheOfTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Führt die Abfrage aus, um die Schule eines Lehrers zu erhalten.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SchoolBrancheDto> Handle(GetBrancheOfTeacher request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetTeachersSchoolBranch(request.TeacherId);
        }
    }
}
