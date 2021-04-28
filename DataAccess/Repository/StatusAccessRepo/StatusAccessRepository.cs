using InexikaTaskServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InexikaTaskServer.DataAccess.Repository
{
    public class StatusAccessRepository : BaseRepository<StatusAccess>, IStatusAccessRepository
    {
        public StatusAccessRepository(DbContext db) : base(db)
        {
        }

        public List<StatusAccess> GetAccesses(int roleId, string[] accessTypeNames)
        {
            var accesses = _dbSet
                .Where(a => a.RoleID == roleId)
                .Include(a => a.AccessType)
                .Include(a => a.Role)
                .Include(a => a.Status)
                .ToList();

            return accesses.Where(a => Array.Exists(accessTypeNames, name => a.AccessType.Name == name)).ToList();
        }
    }
}
