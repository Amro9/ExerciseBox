
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
                Id = Guid.Parse(subject.id),
                Name = subject.name,
                Shortcut = subject.shortcut
            };
        }
        public static implicit operator Subjects(SubjectDto subject)
        {
            return new Subjects
            {
                id = subject.Id.ToString(),
                name = subject.Name,
                shortcut = subject.Shortcut
            };
        }
    }
}
