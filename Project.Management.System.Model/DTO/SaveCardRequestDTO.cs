namespace Project.Management.System.Model.DTO
{
    public class SaveCardRequestDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string Priority { get; set; }
        public string Estimate { get; set; }
    }
}
