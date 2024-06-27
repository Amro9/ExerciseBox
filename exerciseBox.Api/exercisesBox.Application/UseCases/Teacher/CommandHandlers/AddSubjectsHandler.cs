using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Command-Handler zum hinzufügen von Fächern zu einem Lehrer.
    /// </summary>
    public class AddSubjectsHandler : IRequestHandler<AddSubjects>
    {
        private readonly ITeacherRepository _teacherRepository;

        /// <summary>
        /// Konstruktor für den AddSubjectsHandler.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public AddSubjectsHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Verarbeitet den Befehl zum Hinzufügen von Fächern zu einem Lehrer.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(AddSubjects request, CancellationToken cancellationToken)
        {
            await _teacherRepository.AddSubjects(request.TeacherId, request.SubjectIds);
        }
    }
}
