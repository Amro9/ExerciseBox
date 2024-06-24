using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.Queries
{
    public class GetPublicQuestionsBySubject : IRequest<IEnumerable<QuestionDto>>
    {
        public string Subject { get; set; }
        public GetPublicQuestionsBySubject(string subject)
        {
            Subject = subject;
        }
    }
}
