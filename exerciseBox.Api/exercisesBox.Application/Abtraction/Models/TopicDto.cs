
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    public class TopicDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public SubjectDto Subject { get; set; }
        
         
        public static implicit operator TopicDto(Topics topic)
        {
            return new TopicDto
            {
                Id = Guid.Parse(topic.id),
                Description = topic.description,
                Subject = topic.subjectNavigation
            };
        }
        public static implicit operator Topics(TopicDto topic)
        {
            return new Topics
            {
                id = topic.Id.ToString(),
                description = topic.Description,
                subjectNavigation = topic.Subject
            };
        }
    }
}
