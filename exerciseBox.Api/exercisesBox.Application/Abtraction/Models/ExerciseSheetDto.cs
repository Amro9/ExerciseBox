using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Models
{
    public class ExerciseSheetDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool StudentName { get; set; }
        public bool Mark { get; set; }
        public bool Date { get; set; }
        public bool ClassNumber { get; set; }
        public string ClassNumberText { get; set; }
        public bool Subject { get; set; }
        public string SubjectText { get; set; }
        public List<QuestionDto> Questions { get; set; }

        public static implicit operator ExerciseSheetDto(ExerciseSheet v)
        {
            return new ExerciseSheetDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                StudentName = v.StudentName,
                Mark = v.Mark,
                Date = v.Date,
                ClassNumber = v.ClassNumber,
                ClassNumberText = v.ClassNumberText,
                Subject = v.Subject,
                SubjectText = v.SubjectText,
                //Questions = v.Questions.Select(q => (QuestionDto)q).ToList()
            };
        }

        public static implicit operator ExerciseSheet(ExerciseSheetDto v)
        {
            return new ExerciseSheet
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                StudentName = v.StudentName,
                Mark = v.Mark,
                Date = v.Date,
                ClassNumber = v.ClassNumber,
                ClassNumberText = v.ClassNumberText,
                Subject = v.Subject,
                SubjectText = v.SubjectText,
                //Questions = v.Questions.Select(q => (Question)q).ToList()
            };
        }
    }
}
