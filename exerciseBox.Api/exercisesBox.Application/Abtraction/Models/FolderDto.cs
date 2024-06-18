using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class FolderDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Topic { get; set; }

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
            Topic = folder.Topic
        };
    }

    public static implicit operator Folders(FolderDto folder)
    {
        return new Folders
        {
            Id = folder.Id,
            Name = folder.Name,
            Topic = folder.Topic
        };
    }
}
