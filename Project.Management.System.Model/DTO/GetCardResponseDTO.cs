using Project.Management.System.Model.DTO.Common;
using System.Collections.Generic;

namespace Project.Management.System.Model.DTO
{
    public class GetCardResponseDTO
    {
        public int CardId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string Priority { get; set; }
        public string Estimate { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public IEnumerable<Cards> Cards { get; set; }
    }
}
