
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
                Id = Guid.Parse(topic.Id),
                Description = topic.Description,
                Subject = topic.SubjectNavigation
            };
        }
        public static implicit operator Topics(TopicDto topic)
        {
            return new Topics
            {
                Id = topic.Id.ToString(),
                Description = topic.Description,
                SubjectNavigation = topic.Subject
            };
        }
    }
}
