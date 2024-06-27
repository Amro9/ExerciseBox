using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.Queries
{
    /// <summary>
    /// Befehl zum hollen des Ordner mit den erstellten Fragen eines Faches.
    /// </summary>
    public class GetCreationFolder : IRequest<FolderDto>
    {
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
    }
}
