using InexikaTaskServer.DataAccess.Repository;
using System;

namespace InexikaTaskServer.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        void Register(IRepository repository);
        T GetRepository<T>() where T : class, IRepository;
    }
}
