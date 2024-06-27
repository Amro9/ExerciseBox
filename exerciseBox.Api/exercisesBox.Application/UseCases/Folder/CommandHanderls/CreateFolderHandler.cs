using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Folder.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.CommandHanderls
{
    public class CreateFolderHandler : IRequestHandler<CreateFolder, FolderDto>
    {
        private readonly IFolderRepository _folderRepository;

        public CreateFolderHandler(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<FolderDto> Handle(CreateFolder request, CancellationToken cancellationToken)
        {
            return await _folderRepository.CreateAsync(new Domain.Entities.Folders
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Subject = request.SubjectId,
                Teacher = request.TeacherId,
                IsCreationFolder = false
            });
        }
    }
}
