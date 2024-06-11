namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Givenname { get; set; }
        public string SchoolId { get; set; }
        public string SessionId { get; set; }
    }
}
