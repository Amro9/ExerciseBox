using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    public class GetPublicQuestionsBySubjectHandler : IRequestHandler<GetPublicQuestionsBySubject, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetPublicQuestionsBySubjectHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<IEnumerable<QuestionDto>> Handle(GetPublicQuestionsBySubject request, CancellationToken cancellationToken)
        {
           var questions = await _questionRepository.GetQuestionsBySubject(request.Subject);
            return questions.MapToQuestionDto();
        }
    }
}
