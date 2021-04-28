using System.Collections.Generic;

namespace InexikaTaskServer.Contracts
{
    public class WorktaskDto
    {
        public string TaskId { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int EditorId { get; set; }
        public string EditorName { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public bool CanBeDeleted { get; set; }
        public bool CanBeEdited { get; set; }
        public Transition[] CanTransitToStatuses { get; set; }
        public CommentDto[] Comments { get; set; }
        public int CommentCount { get; set; }
    }

    public class Transition
    {
        public string Status { get; set; }
        public bool NeedComment { get; set; }
    }
}
