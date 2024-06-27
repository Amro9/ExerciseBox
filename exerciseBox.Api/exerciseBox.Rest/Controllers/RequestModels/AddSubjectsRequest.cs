namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class AddSubjectsRequest
    {
        public string TeacherId { get; set; }
        public string[] SubjectIds { get; set; }
    }
}
