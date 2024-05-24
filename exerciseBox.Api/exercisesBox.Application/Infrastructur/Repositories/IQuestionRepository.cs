using exerciseBox.Application.Infrastruktur.Repositories;

namespace exerciseBox.Application.Infrastructur.Repositories
{
    public interface IQuestionRepository: IRepository<IQuestionRepository, Guid>
    {
    }
}
