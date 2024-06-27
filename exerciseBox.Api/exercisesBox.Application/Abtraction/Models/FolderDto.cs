using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class FolderDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string SubjectId { get; set; }
    public SubjectDto Subject { get; set; }
    public bool IsCreationFolder { get; set; }  

    public static implicit operator FolderDto(Folders folder)
    {
        if (folder == null)
        {
            return null;
        }
        return new FolderDto
        {
            Id = folder.Id,
            Name = folder.Name,
            SubjectId = folder.Subject,
            Subject = folder.SubjectNavigation,
            IsCreationFolder = folder.IsCreationFolder
        };
    }

    public static implicit operator Folders(FolderDto folder)
    {
        return new Folders
        {
            Id = folder.Id,
            Name = folder.Name,
            Subject = folder.SubjectId,
            IsCreationFolder = folder.IsCreationFolder
        };
    }
}
