using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InexikaTaskServer.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FIO { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        [InverseProperty("Author")]
        public List<Worktask> AuthoredWorktasks { get; set; }

        [InverseProperty("Editor")]
        public List<Worktask> EditedWorktasks { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
