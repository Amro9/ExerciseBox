﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace exerciseBox.Domain.Entities;

public partial class SchoolsBranchesJunction
{
    public string Id { get; set; }

    public string School { get; set; }

    public string Branch { get; set; }

    public virtual SchoolBranches BranchNavigation { get; set; }

    public virtual Schools SchoolNavigation { get; set; }
}