using InexikaTaskServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InexikaTaskServer.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext db): base(db)
        {
        }
        public Employee GetByIdWithAccesses(int id)
        {
            return _dbSet
                .Where(employee => employee.EmployeeId == id)
                .Include(employee => employee.Role)
                .ThenInclude(role => role.StatusRouteAccesses)
                .Include(employee => employee.Role)
                .ThenInclude(role => role.StatusAccesses)
                .ThenInclude(a => a.AccessType)
                .Single();
        }
        public IEnumerable<Employee> GetAllWithRoles()
        {
            return _dbSet
                .Include(employee => employee.Role)
                .ThenInclude(role => role.StatusAccesses)
                .ThenInclude(a => a.AccessType)
                .ToList();
        }
    }
}
