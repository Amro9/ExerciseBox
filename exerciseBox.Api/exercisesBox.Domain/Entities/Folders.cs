﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace exerciseBox.Domain.Entities;

public partial class Folders
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Teacher { get; set; }

    public bool IsCreationFolder { get; set; }

    public string Subject { get; set; }

    public virtual ICollection<FoldersQuestionsJunction> FoldersQuestionsJunction { get; set; } = new List<FoldersQuestionsJunction>();

    public virtual Subjects SubjectNavigation { get; set; }

    public virtual Teachers TeacherNavigation { get; set; }
}