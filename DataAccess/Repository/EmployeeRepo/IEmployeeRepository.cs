using InexikaTaskServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InexikaTaskServer.DataAccess.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByIdWithAccesses(int id);
        IEnumerable<Employee> GetAllWithRoles();
    }
}
