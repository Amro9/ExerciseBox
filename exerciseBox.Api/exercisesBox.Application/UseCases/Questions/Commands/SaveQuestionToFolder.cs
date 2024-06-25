using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.Commands
{
    public class SaveQuestionToFolder : IRequest<int>
    {
        public string JunctionId { get; set; }
        public string FolderId { get; set; }
        public string QuestionId { get; set; }
        public SaveQuestionToFolder(string junctionId ,  string folderId, string questionId)
        {
            
            JunctionId = junctionId;
            FolderId = folderId;
            QuestionId = questionId;
        }
    }
}
