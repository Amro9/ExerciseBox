using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    // we will pass the query to the interface, and if you have an expected output then a second para
    // so the query is the request, and the request handler is this
    public class GetAllPublicQuestionsHandler : IRequestHandler<GetAllPublicQuestions, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetAllPublicQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        // implemented method of mediator, you get the request and handle it. token is optional
        public async Task<IEnumerable<QuestionDto>> Handle(GetAllPublicQuestions request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.ReadAsync();
            return QuestionMappingExtension.MapToQuestionDto(questions);
        }    }
}
