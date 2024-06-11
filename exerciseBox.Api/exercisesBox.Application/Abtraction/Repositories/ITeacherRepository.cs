using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface ITeacherRepository : IRepository<Teachers, string>
{
    Task<Teachers> ReadByEmailAsync(string email);
    Task<IEnumerable<Teachers>> ReadBySchoolIdAsync(string schoolId);
}
