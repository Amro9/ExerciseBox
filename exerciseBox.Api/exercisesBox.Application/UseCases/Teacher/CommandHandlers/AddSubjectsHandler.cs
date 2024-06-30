using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Commands;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.CommandHandlers
{
    /// <summary>
    /// Command-Handler zum hinzufügen von Fächern zu einem Lehrer.
    /// </summary>
    public class AddSubjectsHandler : IRequestHandler<AddSubject>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IFolderRepository _folderRepository;

        /// <summary>
        /// Konstruktor für den AddSubjectsHandler.
        /// </summary>
        /// <param name="teacherRepository"></param>
        public AddSubjectsHandler(ITeacherRepository teacherRepository, IFolderRepository folderRepository)
        {
            _teacherRepository = teacherRepository;
            _folderRepository = folderRepository;
        }

        /// <summary>
        /// Verarbeitet den Befehl zum Hinzufügen von Fächern zu einem Lehrer.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(AddSubject request, CancellationToken cancellationToken)
        {
            await _teacherRepository.AddSubject(request.TeacherId, request.SubjectId);
            
            var folder = await _folderRepository.GetCreationFolder(request.SubjectId, request.TeacherId);

            if(folder == null)
            {
                await _folderRepository.CreateAsync(new Folders
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Erstellte Fragen",
                    Subject = request.SubjectId,
                    Teacher = request.TeacherId,
                    IsCreationFolder = true
                });
            }

        }
    }
}
