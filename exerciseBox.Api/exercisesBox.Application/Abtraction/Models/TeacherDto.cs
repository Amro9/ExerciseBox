using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

/// <summary>
/// Datenübertragungsobjekt für Lehrer.
/// </summary>
public class TeacherDto
{
    /// <summary>
    /// Ruft den Nachnamen des Lehrers ab oder legt diesen fest.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Ruft den Vornamen des Lehrers ab oder legt diesen fest.
    /// </summary>
    public string Givenname { get; set; }

    /// <summary>
    /// Ruft die E-Mail-Adresse des Lehrers ab oder legt diese fest.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Ruft die ID der Schule ab oder legt diese fest.
    /// </summary>
    public string SchoolId { get; set; }

    /// <summary>
    /// Ruft das Passwort des Lehrers ab oder legt dieses fest.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Ruft die Schule des Lehrers ab oder legt diese fest.
    /// </summary>
    public SchoolDto School { get; set; }

    /// <summary>
    /// Konvertiert ein Teachers-Objekt implizit in ein TeacherDto-Objekt.
    /// </summary>
    public static implicit operator TeacherDto(Teachers teacher)
    {
        return new TeacherDto
        {
            Surname = teacher.Surname,
            Givenname = teacher.FamilyName,
            Email = teacher.Email,
            School = teacher.SchoolNavigation is null ? null : teacher.SchoolNavigation,
        };
    }

    /// <summary>
    /// Konvertiert ein TeacherDto-Objekt implizit in ein Teachers-Objekt.
    /// </summary>
    public static implicit operator Teachers(TeacherDto teacher)
    {
        return new Teachers
        {
            Surname = teacher.Surname,
            FamilyName = teacher.Givenname,
            Email = teacher.Email,
            Password = teacher.Password is null ? null : teacher.Password,
            SchoolNavigation = teacher.School is null ? null : teacher.School,
            School = teacher.SchoolId is null ? null : teacher.SchoolId,
        };
    }
}
