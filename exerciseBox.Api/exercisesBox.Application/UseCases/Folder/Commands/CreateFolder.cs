using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.Commands
{
    public class CreateFolder : IRequest<FolderDto>
    {
        public string Name { get; set; }
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
    }
}
