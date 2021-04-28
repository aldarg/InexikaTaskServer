using System.Collections.Generic;

namespace InexikaTaskServer.Models
{
    public class AccessType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<StatusAccess> StatusAccesses { get; set; }
    }
}
