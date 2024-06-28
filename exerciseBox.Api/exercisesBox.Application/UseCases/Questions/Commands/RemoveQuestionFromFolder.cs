using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.Commands
{
    public class RemoveQuestionFromFolder : IRequest<int>
    {
        public string FolderId { get; set; }
        public string QuestionId { get; set; }

        public RemoveQuestionFromFolder( string folderId, string questionId)
        {
            FolderId = folderId;
            QuestionId = questionId;
        }
    }
}
