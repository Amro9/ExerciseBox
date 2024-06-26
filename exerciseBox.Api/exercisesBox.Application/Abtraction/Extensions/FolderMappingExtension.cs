using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions;

public static class FolderMappingExtension
{
    public static IEnumerable<FolderDto> MapToFolderDto(this IEnumerable<Folders> folders)
    {
        return folders.Select(f => (FolderDto)f );
    }

    public static IEnumerable<Folders> MapToFolders(this IEnumerable<FolderDto> folders)
    {
        return folders.Select(f => (Folders)f );
    }
    
}

