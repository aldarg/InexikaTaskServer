namespace InexikaTaskServer.Contracts
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string TaskId { get; set; }
    }
}
