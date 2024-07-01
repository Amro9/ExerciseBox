using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Themen zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class TopicMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="Topics"/> zu einer Sammlung von <see cref="TopicDto"/>.
        /// </summary>
        /// <param name="topics">Die Sammlung der <see cref="Topics"/>.</param>
        /// <returns>Eine Sammlung von <see cref="TopicDto"/>.</returns>
        public static IEnumerable<TopicDto> MapToTopicDto(this IEnumerable<Topics> topics)
        {
            return topics.Select(topic => new TopicDto
            {
                Id = Guid.Parse(topic.Id),
                Subject = topic.SubjectNavigation,
                Description = topic.Description
            });
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="TopicDto"/> zu einer Sammlung von <see cref="Topics"/>.
        /// </summary>
        /// <param name="topics">Die Sammlung der <see cref="TopicDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="Topics"/>.</returns>
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
