namespace InexikaTaskServer.Contracts
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool CanCreate { get; set; }
    }
}
