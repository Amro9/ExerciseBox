using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Topics.Queries
{
    public class GetTopicById: IRequest<TopicDto>
    {
        public string Id { get; set; }
        public GetTopicById(string id)
        {
            Id = id;
        }
    }
}
