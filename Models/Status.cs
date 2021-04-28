using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InexikaTaskServer.Models
{
    public class Status
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public List<Worktask> Worktasks { get; set; }
        public List<StatusAccess> WorktaskAccesses { get; set; } = new List<StatusAccess>();
        public List<StatusRoute> FromStatusRoutes { get; set; } = new List<StatusRoute>();
        public List<StatusRoute> ToStatusRoutes { get; set; } = new List<StatusRoute>();
    }
}
