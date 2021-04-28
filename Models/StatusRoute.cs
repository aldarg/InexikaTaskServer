using System.Collections.Generic;

namespace InexikaTaskServer.Models
{
    public class StatusRoute
    {
        public int ID { get; set; }
        public string FromStatusId { get; set; }
        public Status FromStatus { get; set; }
        public string ToStatusId { get; set; }
        public Status ToStatus { get; set; }
        public bool NeedComment { get; set; }
        public List<StatusRouteAccess> StatusRouteAccesses { get; set; } = new List<StatusRouteAccess>();
    }
}
