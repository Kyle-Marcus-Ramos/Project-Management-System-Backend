using System;

namespace Project.Management.System.Model.DTO
{
    public class UpdateCardRequestDTO
    {
        public int CardId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string Priority { get; set; }
        public int? ProjectId { get; set; }
        public int Position { get; set; }
        public DateTime? Estimate { get; set; }
    }
}
