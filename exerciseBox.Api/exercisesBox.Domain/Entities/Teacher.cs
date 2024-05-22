namespace exerciseBox.Domain.Entities;

public class Teacher
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public School School { get; set; }

}
