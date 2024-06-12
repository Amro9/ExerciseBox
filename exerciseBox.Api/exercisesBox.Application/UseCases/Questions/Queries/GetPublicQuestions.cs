using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.Queries;

    public class GetPublicQuestions : IRequest<IEnumerable<QuestionDto>>
    {
        
    }

