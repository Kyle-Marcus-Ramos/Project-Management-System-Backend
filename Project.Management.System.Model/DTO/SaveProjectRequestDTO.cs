using System.Collections.Generic;

namespace Project.Management.System.Model.DTO
{
    public class SaveProjectRequestDTO
    {
        public List<string> Email { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
    }
}
