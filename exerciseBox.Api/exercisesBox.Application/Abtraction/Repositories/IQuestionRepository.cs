using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface IQuestionRepository: IRepository<Questions, Guid>
{
    Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds);
    Task<IEnumerable<Questions>> GetFolderQuestions(string folderid);
    Task<IEnumerable<Questions>> GetQuestionsBySubject(string subject);
    Task<int> SaveQuestionToFolder(string junctionId, string folderId, string questionId);
    Task<bool> HideQuestion(string teacherId, string questionId);
  Task<bool> IsQuestionHidden(string teacherId, string questionId);
}
