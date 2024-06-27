using exerciseBox.Application.Abtraction.Models;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class TeacherUpdateRequest
    {
        public string Surname { get; set; }
        public string Givenname { get; set; }
        public string Email { get; set; }
        public string SchoolId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public static implicit operator TeacherDto(TeacherUpdateRequest request)
        {
            return new TeacherDto
            {
                Surname = request.Surname,
                Givenname = request.Givenname,
                Email = request.Email,
                SchoolId = request.SchoolId,
                Password = request.Password,
                IsActive = request.IsActive
            };
        }
    }

}
