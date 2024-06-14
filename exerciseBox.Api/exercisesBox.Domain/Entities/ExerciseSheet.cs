namespace exerciseBox.Domain.Entities;

public class ExerciseSheet
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

}
