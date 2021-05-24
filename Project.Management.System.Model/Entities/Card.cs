using System;

namespace Project.Management.System.Model.Entities
{
    public class Card : BaseEntity
    {
        public int ProjectId { get; set; }
        public Projects Project { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string Priority { get; set; }
        public DateTime? Estimate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
