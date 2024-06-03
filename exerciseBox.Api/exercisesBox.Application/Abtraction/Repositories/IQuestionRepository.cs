using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface IQuestionRepository: IRepository<Questions, Guid>
{

}
