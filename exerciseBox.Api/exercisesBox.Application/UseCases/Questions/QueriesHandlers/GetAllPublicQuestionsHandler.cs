using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    /// <summary>
    /// Handler für die Anforderung, alle öffentlichen Fragen abzurufen.
    /// </summary>
    public class GetAllPublicQuestionsHandler : IRequestHandler<GetAllPublicQuestions, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        /// <summary>
        /// Konstruktor für den Handler zur Abfrage aller öffentlichen Fragen.
        /// </summary>
        /// <param name="questionRepository">Das Repository für Fragen.</param>
        public GetAllPublicQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// Verarbeitet die Anforderung, alle öffentlichen Fragen abzurufen.
        /// </summary>
        /// <param name="request">Die Anforderung, die keine spezifischen Parameter erfordert.</param>
        /// <param name="cancellationToken">Das Abbruchtoken zum Abbrechen des Vorgangs.</param>
        /// <returns>Eine Aufzählung von Frage-DTOs, die auf die Anforderung abgestimmt sind.</returns>
        public async Task<IEnumerable<QuestionDto>> Handle(GetAllPublicQuestions request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.ReadAsync();
            return QuestionMappingExtension.MapToQuestionDto(questions);
        }
    }
}
