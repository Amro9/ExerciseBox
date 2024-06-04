using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Topics.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Topics.QueriesHandlers
{
    public class GetTopicsBySubjectHandler : IRequestHandler<GetTopicsBySubject, IEnumerable<TopicDto>>
    {
        private readonly ITopicRepository _topicRepository;
        public GetTopicsBySubjectHandler (ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task<IEnumerable<TopicDto>> Handle(GetTopicsBySubject request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.ReadBySubject(request.Subject);
            return topics.MapToTopicDto();
        }
    }
}
