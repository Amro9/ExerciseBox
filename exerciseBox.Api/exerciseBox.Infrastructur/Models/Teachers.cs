﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace exerciseBox.Infrastructur.Models;

public partial class Teachers
{
    public string id { get; set; }

    public string surname { get; set; }

    public string familyName { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public string school { get; set; }

    public virtual ICollection<Questions> Questions { get; set; } = new List<Questions>();

    public virtual ICollection<TeachersSchoolLevelsJunctions> TeachersSchoolLevelsJunctions { get; set; } = new List<TeachersSchoolLevelsJunctions>();

    public virtual ICollection<TeachersSubjectsJunctions> TeachersSubjectsJunctions { get; set; } = new List<TeachersSubjectsJunctions>();

    public virtual Schools schoolNavigation { get; set; }
}