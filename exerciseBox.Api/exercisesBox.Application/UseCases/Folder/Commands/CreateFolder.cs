using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.Commands
{
    public class CreateFolder : IRequest<FolderDto>
    {
        public FolderDto Folder { get; set; }
    }
}
