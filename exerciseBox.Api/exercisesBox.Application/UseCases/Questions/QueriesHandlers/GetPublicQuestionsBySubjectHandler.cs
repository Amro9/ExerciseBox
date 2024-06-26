using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    /// <summary>
    /// Handler für die Anforderung, öffentliche Fragen nach einem bestimmten Fach zu erhalten.
    /// </summary>
    public class GetPublicQuestionsBySubjectHandler : IRequestHandler<GetPublicQuestionsBySubject, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        /// <summary>
        /// Konstruktor für den Handler zur Abfrage öffentlicher Fragen nach einem bestimmten Fach.
        /// </summary>
        /// <param name="questionRepository">Das Repository für Fragen.</param>
        public GetPublicQuestionsBySubjectHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// Verarbeitet die Anforderung, öffentliche Fragen nach einem bestimmten Fach zu erhalten.
        /// </summary>
        /// <param name="request">Die Anforderung, die das Fach enthält, nach dem gefragt wird.</param>
        /// <param name="cancellationToken">Das Abbruchtoken zum Abbrechen des Vorgangs.</param>
        /// <returns>Eine Aufzählung von Frage-DTOs, die auf die Anforderung abgestimmt sind.</returns>
        public async Task<IEnumerable<QuestionDto>> Handle(GetPublicQuestionsBySubject request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsBySubject(request.Subject);
            return questions.MapToQuestionDto();
        }
    }
}
