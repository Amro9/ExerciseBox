using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Folder.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.QueryHandlers;

public class GetFoldersOfTeacherHandler : IRequestHandler<GetFoldersOfTeacher, IEnumerable<FolderDto>>
{
    private readonly IFolderRepository _folderRepository;

    public GetFoldersOfTeacherHandler(IFolderRepository folderRepository)
    {
        _folderRepository = folderRepository;
    }
    public async Task<IEnumerable<FolderDto>> Handle(GetFoldersOfTeacher request, CancellationToken cancellationToken)
    {
        var folders = await _folderRepository.GetFoldersByTeacherId(request.TeacherId);
        return folders.MapToFolderDto();
    }
}
