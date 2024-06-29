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
    public class GetTopicByIdHandler : IRequestHandler<GetTopicById, TopicDto>
    { 
        private readonly ITopicRepository _topicRepository;
    public GetTopicByIdHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task<TopicDto> Handle(GetTopicById request, CancellationToken cancellationToken)
        {
            return await _topicRepository.ReadByIdAsync(request.Id);
        }
    }
}
