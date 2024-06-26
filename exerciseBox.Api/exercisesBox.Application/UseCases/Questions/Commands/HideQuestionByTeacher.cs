using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.Questions.Commands
{
    public class HideQuestionByTeacher : IRequest<bool>
    {
        public string QuestionId { get; set; }
        public string TeacherId { get; set; }
        public HideQuestionByTeacher(string question, string teacher)
        {
                 QuestionId = question;
            TeacherId = teacher;

        }
    }
}
