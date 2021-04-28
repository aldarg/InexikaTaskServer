using System.Collections.Generic;

namespace InexikaTaskServer.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<StatusAccess> StatusAccesses { get; set; } = new List<StatusAccess>();
        public List<StatusRouteAccess> StatusRouteAccesses { get; set; } = new List<StatusRouteAccess>();
    }
}
