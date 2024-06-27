using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.Queries
{
    public class GetHiddenQuestionsByTeacher : IRequest<IEnumerable<QuestionDto>>
    {
        public string TeacherId
            { get; set; }
        public GetHiddenQuestionsByTeacher(string teacherId)
        {
            TeacherId = teacherId;
                
        }
    }
}
