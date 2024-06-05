
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    public class SubjectDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Shortcut { get; set; }
        public static implicit operator SubjectDto(Subjects subject)
        {
            return new SubjectDto
            {
                Id = Guid.Parse(subject.Id),
                Name = subject.Name,
                Shortcut = subject.Shortcut
            };
        }
        public static implicit operator Subjects(SubjectDto subject)
        {
            return new Subjects
            {
                Id = subject.Id.ToString(),
                Name = subject.Name,
                Shortcut = subject.Shortcut
            };
        }
    }
}
