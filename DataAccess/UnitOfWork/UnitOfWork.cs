using InexikaTaskServer.DataAccess.Repository;
using System;

namespace InexikaTaskServer.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorktaskDbContext _db;
        public UnitOfWork(WorktaskDbContext db)
        {
            _db = db;
        }
        public void Register(IRepository repository)
        {
            throw new System.NotImplementedException();
        }
        public T GetRepository<T>() where T : class, IRepository
        {
            if (typeof(T) == typeof(IEmployeeRepository))
            {
                return new EmployeeRepository(_db) as T;
            }

            if (typeof(T) == typeof(IWorktaskRepository))
            {
                return new WorktaskRepository(_db) as T;
            }

            if (typeof(T) == typeof(IStatusAccessRepository))
            {
                return new StatusAccessRepository(_db) as T;
            }
            if (typeof(T) == typeof(ICommentRepository))
            {
                return new CommentRepository(_db) as T;
            }

            throw new Exception("Неизвестный тип репозитория:" + typeof(T));
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
