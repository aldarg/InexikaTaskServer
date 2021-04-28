namespace InexikaTaskServer.Models
{
    public class StatusAccess
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int AccessTypeId { get; set; }
        public AccessType AccessType { get; set; }
        public bool? OnlyAuthored { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
