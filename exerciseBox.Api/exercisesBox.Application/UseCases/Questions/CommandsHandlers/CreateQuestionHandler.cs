using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.CommandHandlers
{
    /// <summary>
    /// Befehlsbehandlung zum Erstellen einer neuen Frage.
    /// </summary>
    public class CreateQuestionHandler : IRequestHandler<CreateQuestion, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly ISchoolBranchesRepository _schoolBranchesRepository;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="CreateQuestionHandler"/> Klasse.
        /// </summary>
        /// <param name="questionRepository">Das Repository für Fragen.</param>
        /// <param name="teacherRepository">Das Repository für Lehrer.</param>
        /// <param name="schoolTypeRepository">Das Repository für Schularten.</param>
        /// <param name="schoolBranchesRepository">Das Repository für Schulzweige.</param>
        public CreateQuestionHandler(
            IQuestionRepository questionRepository,
            ISchoolTypeRepository schoolTypeRepository,
            ITeacherRepository teacherRepository,
            ISchoolBranchesRepository schoolBranchesRepository
        )
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _schoolTypeRepository = schoolTypeRepository ?? throw new ArgumentNullException(nameof(schoolTypeRepository));
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
            _schoolBranchesRepository = schoolBranchesRepository ?? throw new ArgumentNullException(nameof(schoolBranchesRepository));
        }

        /// <summary>
        /// Führt die Behandlung des Befehls zum Erstellen einer neuen Frage aus.
        /// </summary>
        /// <param name="request">Der Befehl zum Erstellen einer neuen Frage.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchsteuerung.</param>
        /// <returns>Die erstellte Frage als <see cref="QuestionDto"/>.</returns>
        public async Task<QuestionDto> Handle(CreateQuestion request, CancellationToken cancellationToken)
        {
            var branch = await _teacherRepository.GetTeachersSchoolBranch(request.Question.Author);
            request.Question.SchoolBranch = branch.Id;
            request.Question.SchoolType = await _schoolTypeRepository.ReadIdByTeacher(request.Question.Author);

            var question = await _questionRepository.CreateAsync(request.Question);
            if (question == null)
            {
                throw new Exception("Fehler beim Erstellen der Frage.");
            }
            return question;
        }
    }
}
