using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Subject.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exerciseBox.Application.UseCases.Subject.QueriesHandlers
{
    public class GetSubjectByIdHandler : IRequestHandler<GetSubjectById, SubjectDto>
    {
        private readonly ISubjectRepository _subjectRepository;
        public GetSubjectByIdHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<SubjectDto> Handle(GetSubjectById request, CancellationToken cancellationToken)
        {
            Guid.TryParse(request.Id, out Guid idGuid);
            return await _subjectRepository.ReadByIdAsync(idGuid);
        }
    }
}
