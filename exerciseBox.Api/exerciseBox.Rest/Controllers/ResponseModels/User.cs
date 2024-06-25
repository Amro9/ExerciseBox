using exerciseBox.Application.Abtraction.Models;

namespace exerciseBox.Rest.Controllers.ResponseModels;

public class User
{
    public string Email { get; set; }
    public string Role { get; set; }

    public static implicit operator User(TeacherDto v)
    {
        if(v == null)
        {
            return null;
        }

        return new User
        {
            Email = v.Email
        };
    }

    public static implicit operator User(SchoolDto v)
    {
        if(v == null)
        {
            return null;
        }
        return new User
        {
            Email = v.Email
        };
    }
}
