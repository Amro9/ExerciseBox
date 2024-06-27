using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Folder.Queries;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.QueryHandlers
{
    /// <summary>
    /// Command-Handler zur Behandlung des Befehls zum hollen des Ordner mit den erstellten Fragen eines Faches.
    /// </summary>  
    public class GetCreationFolderHandler : IRequestHandler<GetCreationFolder, FolderDto>
    {
        private readonly IFolderRepository _folderRepository;

        /// <summary>
        /// Konstruktor für den GetOrCreateCreationFolderHandler.
        /// </summary>
        /// <param name="folderRepository">Das Repository, das für die Datenbankoperationen mit Ordnern verwendet wird.</param>
        public GetCreationFolderHandler(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<FolderDto> Handle(GetCreationFolder request, CancellationToken cancellationToken)
        {
            return await _folderRepository.GetCreationFolder(request.SubjectId, request.TeacherId);
        }
    }
}
