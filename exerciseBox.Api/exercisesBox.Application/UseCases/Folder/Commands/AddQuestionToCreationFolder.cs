using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace exerciseBox.Application.UseCases.Folder.Commands
{
    /// <summary>
    /// Command zum Hinzufügen einer Frage zu einem Creation Ordner eines Faches.
    /// </summary>
    public class AddQuestionToCreationFolder : IRequest
    {
        public QuestionDto Question { get; set; }
    }
}
