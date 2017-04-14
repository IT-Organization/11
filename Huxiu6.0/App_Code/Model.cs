﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Activity
{
    public int ActivityId { get; set; }
    public string ActivityTitle { get; set; }
    public string ActivityWhat { get; set; }
    public string ActivityWhere { get; set; }
    public string ActivityWhen { get; set; }
    public string ActivityTips { get; set; }
    public string ActivityImage { get; set; }
    public bool IsDel { get; set; }
    public Nullable<bool> IsHeadline { get; set; }
}

public partial class Admin
{
    public int AdminId { get; set; }
    public string AdminName { get; set; }
    public string AdminPassword { get; set; }
    public bool AdminSex { get; set; }
    public string AdminProblem { get; set; }
    public string AdminAnswer { get; set; }
    public string AdminImage { get; set; }
}

public partial class Author
{
    public Author()
    {
        this.Passage = new HashSet<Passage>();
    }

    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public bool AuthorSex { get; set; }
    public string AuthorSummary { get; set; }
    public string AuthorImage { get; set; }

    public virtual Author Author1 { get; set; }
    public virtual Author Author2 { get; set; }
    public virtual ICollection<Passage> Passage { get; set; }
}

public partial class DeleteLog
{
    public int DelId { get; set; }
    public string DelTime { get; set; }
    public int DelAdminId { get; set; }
    public int Category { get; set; }
    public int LogId { get; set; }
}

public partial class Headline
{
    public int Id { get; set; }
    public int HId { get; set; }
    public string Htitle { get; set; }
    public string Himg { get; set; }
    public string Hdeadline { get; set; }
    public bool HisDisplay { get; set; }
}

public partial class News
{
    public int NewsId { get; set; }
    public string NewsTitle { get; set; }
    public string NewsBody { get; set; }
    public string NewsLink { get; set; }
    public string NewsDate { get; set; }
    public bool IsDel { get; set; }
    public int NewsAgree { get; set; }
}

public partial class NewsAgree
{
    public int id { get; set; }
    public string UserIp { get; set; }
    public int ItemId { get; set; }
}

public partial class Passage
{
    public int PassageId { get; set; }
    public string PassageTitle { get; set; }
    public string PassageBody { get; set; }
    public string PassageImage { get; set; }
    public int PassageCategory { get; set; }
    public string PublishDate { get; set; }
    public int AuthorId { get; set; }
    public int PageViews { get; set; }
    public bool IsDel { get; set; }

    public virtual Author Author { get; set; }
    public virtual PassageCategory PassageCategory1 { get; set; }
}

public partial class PassageCategory
{
    public PassageCategory()
    {
        this.Passage = new HashSet<Passage>();
    }

    public int PCategoryId { get; set; }
    public string CategoryName { get; set; }

    public virtual ICollection<Passage> Passage { get; set; }
}

public partial class PassageInformation
{
    public int PassageId { get; set; }
    public string PassageTitle { get; set; }
    public string PassageBody { get; set; }
    public int PassageCategory { get; set; }
    public string PublishDate { get; set; }
    public int PageViews { get; set; }
    public string CategoryName { get; set; }
    public bool IsDel { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}
