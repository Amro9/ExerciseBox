using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Folder.Queries
{
    public class GetSubjectFolders: IRequest<IEnumerable<FolderDto>>
    {
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
        public GetSubjectFolders(string subjectId, string teacherId)
        {
            SubjectId = subjectId;
            TeacherId = teacherId;
        }
    }
}
