using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.Queries;

public class GetFoldersOfTeacher : IRequest<IEnumerable<FolderDto>>
{
    public string TeacherId { get; set; }
}
