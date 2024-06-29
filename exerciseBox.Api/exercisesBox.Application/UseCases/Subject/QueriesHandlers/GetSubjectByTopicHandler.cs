using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    public class GetSubjectByTopicHandler : IRequestHandler<GetSubjectByTopic, SubjectDto>
    {
        private readonly ISubjectRepository _subjectRepository;
        public GetSubjectByTopicHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<SubjectDto> Handle(GetSubjectByTopic request, CancellationToken cancellationToken)
        {
           var subject = await _subjectRepository.ReadByTopic(request.TopicId);
            return subject;
        }
    }
}
