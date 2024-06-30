using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Folder.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Folder.QueryHandlers
{
    public class GetSubjectFoldersHandler : IRequestHandler<GetSubjectFolders, IEnumerable<FolderDto>>
    {
        private readonly IFolderRepository _folderRepository;

        public GetSubjectFoldersHandler(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        public async Task<IEnumerable<FolderDto>> Handle(GetSubjectFolders request, CancellationToken cancellationToken)
        {
            var folders=  await _folderRepository.GetSubjectFolders(request.SubjectId, request.TeacherId);
            return folders.MapToFolderDto();
        }
    }
}
