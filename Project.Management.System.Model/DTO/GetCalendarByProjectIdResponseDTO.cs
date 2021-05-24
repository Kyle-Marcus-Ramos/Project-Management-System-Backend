using System;

namespace Project.Management.System.Model.DTO
{
    public class GetCalendarByProjectIdResponseDTO
    {
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Estimate { get; set; }
    }
}
