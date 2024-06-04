using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface ITopicRepository : IRepository<Topics, Guid>
{
    public Task<IEnumerable<Topics>> ReadBySubject(string subject);
}
