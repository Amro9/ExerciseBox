using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    public class GetHiddenQuestionsByTeacherHandler : IRequestHandler<GetHiddenQuestionsByTeacher, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository questionRepository;
        public GetHiddenQuestionsByTeacherHandler(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task<IEnumerable<QuestionDto>> Handle(GetHiddenQuestionsByTeacher request, CancellationToken cancellationToken)
        {
             
            var questions =  await questionRepository.GetHiddenQuestionsByTeacher(request.TeacherId);
            return QuestionMappingExtension.MapToQuestionDto(questions);
        }
    }
}
