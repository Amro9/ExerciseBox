using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Topics.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Topics.QueriesHandlers
{
    public class GetAllTopicsHandler : IRequestHandler<GetAllTopics, IEnumerable<TopicDto>>
    {
   private readonly ITopicRepository _topicRepository;
        public GetAllTopicsHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task<IEnumerable<TopicDto>> Handle(GetAllTopics request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.Read();
            return topics.MapToTopicDto();
        }
    }
}
