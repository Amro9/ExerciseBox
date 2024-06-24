using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Themen.
    /// </summary>
    public class TopicDto
    {
        /// <summary>
        /// Ruft die ID des Themas ab oder legt diese fest.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ruft die Beschreibung des Themas ab oder legt diese fest.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ruft das Fach des Themas ab oder legt dieses fest.
        /// </summary>
        public SubjectDto Subject { get; set; }

        /// <summary>
        /// Konvertiert ein Topics-Objekt implizit in ein TopicDto-Objekt.
        /// </summary>
        public static implicit operator TopicDto(Topics topic)
        {
            if(topic == null)
                return null;

            return new TopicDto
            {
                Id = Guid.Parse(topic.Id),
                Description = topic.Description,
                Subject = topic.SubjectNavigation
            };
        }

        /// <summary>
        /// Konvertiert ein TopicDto-Objekt implizit in ein Topics-Objekt.
        /// </summary>
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

