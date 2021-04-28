using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using InexikaTaskServer.Models;

namespace InexikaTaskServer.DataAccess.Repository
{
    public class WorktaskRepository: BaseRepository<Worktask>, IWorktaskRepository
    {
        public WorktaskRepository(DbContext db) : base(db)
        {
        }
        public bool CreateTask(Worktask task)
        {
            if (_dbSet.Any(t => t.ID == task.ID))
            {
                return false;
            }

            _dbSet.Add(task);
            return true;
        }
        public Worktask GetTaskById(string id)
        {
            return _dbSet.Find(id);
        }
        public Worktask GetWorktaskWithAccesses(string id, Employee employee)
        {
            var task = _dbSet
                .Where(worktask => worktask.ID == id)
                .Include(worktask => worktask.Author)
                .Include(worktask => worktask.Editor)
                .Include(worktask => worktask.Status)
                .ThenInclude(status => status.FromStatusRoutes.Where(r => r.StatusRouteAccesses.Any(a => a.RoleId == employee.RoleID)))
                .Include(w => w.Status)
                .ThenInclude(s => s.WorktaskAccesses.Where(a => a.RoleID == employee.RoleID))
                .ThenInclude(a => a.AccessType)
                .AsSplitQuery()
                .Include(w => w.Comments)
                .ThenInclude(c => c.Author)
                .Single();

            return task;
        }
        public List<Worktask> GetAllWorktasks(Employee employee, List<StatusAccess> accesses, string find)
        {
            var allTasks = _dbSet
                .Where(t => find == null || (find != null && t.Text.Contains(find)))
                .Include(worktask => worktask.Author)
                .Include(worktask => worktask.Editor)
                .Include(worktask => worktask.Status)
                .Include(worktask => worktask.Comments)
                .ThenInclude(c => c.Author)
                .ToList();
                
            var result = allTasks
                .Where(t => accesses.Any(a => a.StatusId == t.StatusId && !((bool)a.OnlyAuthored && t.AuthorId != employee.EmployeeId)))
                .ToList();
            
            return result;
        }
        public void DeleteTask(string id)
        {
            var task = _dbSet.Find(id);
            if (task == null)
            {
                return;
            }
            _dbSet.Remove(task);
        }
    }
}
