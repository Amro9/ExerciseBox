using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface ISchoolLevelRepository : IRepository<SchoolLevels, int>
{
    Task<IEnumerable<int>> ReadByTeacherId(string teacherId);
}
