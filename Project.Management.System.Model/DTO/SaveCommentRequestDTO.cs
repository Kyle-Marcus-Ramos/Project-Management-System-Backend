namespace Project.Management.System.Model.DTO
{
    public class SaveCommentRequestDTO
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
    }
}
