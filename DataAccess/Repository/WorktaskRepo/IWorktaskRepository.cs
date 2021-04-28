using InexikaTaskServer.Models;
using System.Collections.Generic;

namespace InexikaTaskServer.DataAccess.Repository
{
    public interface IWorktaskRepository : IRepository<Worktask>
    {
        bool CreateTask(Worktask task);
        Worktask GetTaskById(string id);
        Worktask GetWorktaskWithAccesses(string id, Employee employee);
        List<Worktask> GetAllWorktasks(Employee employee, List<StatusAccess> accesses, string find);
        void DeleteTask(string id);
    }
}
