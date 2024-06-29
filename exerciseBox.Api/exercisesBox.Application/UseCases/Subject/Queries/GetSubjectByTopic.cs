using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    public class GetSubjectByTopic : IRequest<SubjectDto>
    {
        public string TopicId { get; set; }
        public GetSubjectByTopic(string topicId)
        {
            TopicId = topicId;
        }
    }
}
