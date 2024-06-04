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
                Id = Guid.Parse(topic.id),
                Subject = topic.subjectNavigation,
                Description = topic.description
            });
        }

        public static IEnumerable<Topics> MapToDomainTopics(this IEnumerable<TopicDto> topics)
        {
            return topics.Select(topic => new Topics
            {
                id = topic.Id.ToString(),
                subjectNavigation = topic.Subject,
                description = topic.Description
            });
        }
    }
}
