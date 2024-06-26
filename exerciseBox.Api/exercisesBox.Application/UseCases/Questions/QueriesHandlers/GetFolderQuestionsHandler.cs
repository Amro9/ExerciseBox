using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.QueriesHandlers
{
    /// <summary>
    /// Handler für die Anforderung, Fragen in einem bestimmten Ordner abzurufen.
    /// </summary>
    public class GetFolderQuestionsHandler : IRequestHandler<GetFolderQuestions, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        /// <summary>
        /// Konstruktor für den Handler zur Abfrage von Fragen in einem bestimmten Ordner.
        /// </summary>
        /// <param name="questionRepository">Das Repository für Fragen.</param>
        public GetFolderQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// Verarbeitet die Anforderung, Fragen in einem bestimmten Ordner abzurufen.
        /// </summary>
        /// <param name="request">Die Anforderung, die den Ordner-ID enthält.</param>
        /// <param name="cancellationToken">Das Abbruchtoken zum Abbrechen des Vorgangs.</param>
        /// <returns>Eine Aufzählung von Frage-DTOs, die auf die Anforderung abgestimmt sind.</returns>
        public async Task<IEnumerable<QuestionDto>> Handle(GetFolderQuestions request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetFolderQuestions(request.FolderId);
            return questions.MapToQuestionDto();
        }
    }
}
