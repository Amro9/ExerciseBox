namespace exerciseBox.Rest.Controllers.RequestModels
{
    public class SaveQuestionToFolderRequest
    {
        public Guid JunctionId { get; set; }
        public string FolderId { get; set; }
        public string QuestionId { get; set; }
        public SaveQuestionToFolderRequest()
        {
             JunctionId = Guid.NewGuid();
        }
    }
}
