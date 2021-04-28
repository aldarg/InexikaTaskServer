using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InexikaTaskServer.DataAccess.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        protected DbSet<T> _dbSet;
        public BaseRepository(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
