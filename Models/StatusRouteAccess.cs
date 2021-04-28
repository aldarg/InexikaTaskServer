using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InexikaTaskServer.Models
{
    public class StatusRouteAccess
    {
        public int ID { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int StatusRouteId { get; set; }
        public StatusRoute StatusRoute { get; set; }
    }
}
