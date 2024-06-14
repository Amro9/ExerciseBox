namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class RegisterRequest : BaseRequest
    {
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Givenname { get; set; }
        public string SchoolId { get; set; }
    }
}
