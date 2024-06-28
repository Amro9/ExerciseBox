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
    public class RemoveQuestionFromFolderHandler : IRequestHandler<RemoveQuestionFromFolder, int>
    {
        private readonly IQuestionRepository _questionRepository;
        public RemoveQuestionFromFolderHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<int> Handle(RemoveQuestionFromFolder request, CancellationToken cancellationToken)
        {
            return await _questionRepository.RemoveQuestionFromFolder(request.FolderId, request.QuestionId);
        }
    }
}
