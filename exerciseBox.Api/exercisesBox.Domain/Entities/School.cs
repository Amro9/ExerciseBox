namespace exercisesBox.Domain.Entities;

public sealed class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SchoolType Type { get; set; }
    
}
