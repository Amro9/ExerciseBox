using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.CommandsHandlers
{
    public class SaveQuestionToFolderHandler : IRequestHandler<SaveQuestionToFolder, int>
    {
        private readonly IQuestionRepository _questionRepository;
        public SaveQuestionToFolderHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<int> Handle(SaveQuestionToFolder request, CancellationToken cancellationToken)
        {
            int questionSaved = await _questionRepository.SaveQuestionToFolder(request.JunctionId,request.FolderId, request.QuestionId);
        return questionSaved;
        }
    }
}
