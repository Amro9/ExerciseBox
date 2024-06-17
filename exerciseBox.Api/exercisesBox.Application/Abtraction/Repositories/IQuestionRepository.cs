using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface IQuestionRepository: IRepository<Questions, Guid>
{
    Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds);
    Task<IEnumerable<Questions>> GetFolderQuestions(string folderid);
}
