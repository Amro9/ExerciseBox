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
    public class HideQuestionByTeacherHandler : IRequestHandler<HideQuestionByTeacher, bool>
    {
        private readonly IQuestionRepository _questionRepository;
        public HideQuestionByTeacherHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public Task<bool> Handle(HideQuestionByTeacher request, CancellationToken cancellationToken)
        {
            return  _questionRepository.HideQuestion(request.QuestionId, request.TeacherId);
        }
    }
}
