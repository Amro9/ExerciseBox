﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace exerciseBox.Domain.Entities;

public partial class Questions
{
    public string Id { get; set; }

    public string Content { get; set; }

    public string Answer { get; set; }

    public string Author { get; set; }

    public string DifficultyLevel { get; set; }

    public int SchoolLevel { get; set; }

    public string Topic { get; set; }

    public virtual Teachers AuthorNavigation { get; set; }

    public virtual QuestionDifficultyLevels DifficultyLevelNavigation { get; set; }

    public virtual SchoolLevels SchoolLevelNavigation { get; set; }

    public virtual Topics TopicNavigation { get; set; }
}