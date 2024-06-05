using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    public static class TopicMappingExtension
    {
        public static IEnumerable<TopicDto> MapToTopicDto(this IEnumerable<Topics> topics)
        {
            return topics.Select(topic => new TopicDto
            {
                Id = Guid.Parse(topic.Id),
                Subject = topic.SubjectNavigation,
                Description = topic.Description
            });
        }

        public static IEnumerable<Topics> MapToDomainTopics(this IEnumerable<TopicDto> topics)
        {
            return topics.Select(topic => new Topics
            {
                Id = topic.Id.ToString(),
                SubjectNavigation = topic.Subject,
                Description = topic.Description
            });
        }
    }
}
