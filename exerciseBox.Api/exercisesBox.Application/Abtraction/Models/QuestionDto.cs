﻿
namespace exerciseBox.Application.Abtraction.Models
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public string Author { get; set; }
        public string DifficultyLevel { get; set; }

        public int SchoolLevel { get; set; }

        public string Topic { get; set; }


    }
}
