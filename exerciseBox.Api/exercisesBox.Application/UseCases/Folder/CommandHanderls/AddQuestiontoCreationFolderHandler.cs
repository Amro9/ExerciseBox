using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Folder.Commands;
using exerciseBox.Application.UseCases.Questions.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Folder.CommandHanderls
{
    /// <summary>
    /// Command-Handler zur Behandlung des Befehls zum Hinzufügen einer Frage zu einem Creation Ordner eines Faches.
    public class AddQuestiontoCreationFolderHandler : IRequestHandler<AddQuestionToCreationFolder>
    {
        private readonly IFolderRepository _folderRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IQuestionRepository _questionRepository;

        /// <summary>
        /// Konstruktor für den AddQuestiontoCreationFolderHandler.
        /// </summary>
        /// <param name="folderRepository"></param>
        /// <param name="topicRepository"></param>
        public AddQuestiontoCreationFolderHandler(IFolderRepository folderRepository, ITopicRepository topicRepository, IQuestionRepository questionRepository)
        {
            _folderRepository = folderRepository;
            _topicRepository = topicRepository;
            _questionRepository = questionRepository;
        }


        public async Task Handle(AddQuestionToCreationFolder request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.ReadByIdAsync(request.Question.Topic); 
            var folder = await _folderRepository.GetCreationFolder(topic.Subject, request.Question.Author);

            if (folder == null)
            {
                throw new Exception("Creation Folder not found");
            }

            await _questionRepository.SaveQuestionToFolder(Guid.NewGuid().ToString(),folder.Id, request.Question.Id.ToString());
        }
    }
}
