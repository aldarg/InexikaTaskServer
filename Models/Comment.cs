using System;
using System.ComponentModel.DataAnnotations;

namespace InexikaTaskServer.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public Employee Author { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public string WorktaskId { get; set; }
        public Worktask Worktask { get; set; }
    }
}
