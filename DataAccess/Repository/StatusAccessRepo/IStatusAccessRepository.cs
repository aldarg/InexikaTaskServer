using InexikaTaskServer.Models;
using System.Collections.Generic;

namespace InexikaTaskServer.DataAccess.Repository
{
    interface IStatusAccessRepository : IRepository<StatusAccess>
    {
        List<StatusAccess> GetAccesses(int roleId, string[] accessTypeNames);
    }
}
