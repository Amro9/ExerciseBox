using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    public static class SubjectMappingExtention
    {
        public static IEnumerable<SubjectDto> MaptToSubjectDto(this IEnumerable<Subjects> subjects)
        {
            return subjects.Select(s => new SubjectDto
            {
                Id = Guid.Parse(s.Id),
                Shortcut = s.Shortcut,
                Name = s.Name,
            });
        }
        public static IEnumerable<Subjects> MapToDomainSubjects(this IEnumerable<SubjectDto> subjects)
        {
            return subjects.Select(s => new Subjects
            {
                Id = s.Id.ToString(),
                Shortcut = s.Shortcut,
                Name = s.Name
            });
        }
    }
}
