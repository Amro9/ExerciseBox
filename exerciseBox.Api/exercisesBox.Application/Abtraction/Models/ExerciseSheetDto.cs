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
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool NamePlaceHolder { get; set; }
        public bool MarkPlaceHolder { get; set; }
        public bool DatePlaceHolder { get; set; }
        public bool ClassNumberPlaceHolder { get; set; }
        public string ClassNumberText { get; set; }
        public bool SubjectPlaceHolder { get; set; }
        public string SubjectText { get; set; }
        //public List<QuestionDto> Questions { get; set; }

        public static implicit operator ExerciseSheetDto(ExerciseSheets v)
        {
            return new ExerciseSheetDto
            {
                Id = v.Id,
                Title = v.Tilte,
                NamePlaceHolder = v.NamePlaceHolder,
                MarkPlaceHolder = v.MarkPlaceHolder,
                DatePlaceHolder = v.DatePlaceHolder,
                ClassNumberPlaceHolder = v.ClassNumberPlaceHolder,
                ClassNumberText = v.ClassNumberText,
                SubjectPlaceHolder = v.SubjectPlaceHolder,
                //Questions = v.Questions.Select(q => (QuestionDto)q).ToList()
            };
        }

        public static implicit operator ExerciseSheets(ExerciseSheetDto v)
        {
            return new ExerciseSheets
            {
                Id = v.Id,
                Tilte = v.Title,
                NamePlaceHolder = v.NamePlaceHolder,
                MarkPlaceHolder = v.MarkPlaceHolder,
                DatePlaceHolder = v.DatePlaceHolder,
                ClassNumberPlaceHolder = v.ClassNumberPlaceHolder,
                ClassNumberText = v.ClassNumberText,
                SubjectPlaceHolder = v.SubjectPlaceHolder,
                //Questions = v.Questions.Select(q => (Question)q).ToList()
            };
        }
    }
}
