using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories;

public interface ITeacherRepository : IRepository<Teachers, string>
{
    Task<Teachers> ReadByEmail(string email);
}
