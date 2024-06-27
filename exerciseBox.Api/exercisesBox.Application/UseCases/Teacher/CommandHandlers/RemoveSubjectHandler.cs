using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;
using Microsoft.VisualBasic;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Command-Handler zum entfernen von Fächern von einem Lehrer.
    /// </summary>
    public class RemoveSubjectHandler : IRequestHandler<RemoveSubject>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den RemoveSubjectHandler.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public RemoveSubjectHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet den Befehl zum Entfernen von Fächern von einem Lehrer.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(RemoveSubject request, CancellationToken cancellationToken)
        {
            await _teacherRepository.RemoveSubject(request.TeacherId, request.SubjectId);
        }
    }
}
