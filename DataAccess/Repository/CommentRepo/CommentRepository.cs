using InexikaTaskServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InexikaTaskServer.DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext db) : base(db)
        {
        }
    }
}
