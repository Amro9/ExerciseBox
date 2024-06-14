using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface ISchoolLevelRepository : IRepository<int, int>
{
    Task<IEnumerable<int>> ReadByTeacherId(string teacherId);
}
