using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InexikaTaskServer.Models
{
    public class Worktask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int AuthorId { get; set; }
        public Employee Author { get; set; }
        public int EditorId { get; set; }
        public Employee Editor { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
