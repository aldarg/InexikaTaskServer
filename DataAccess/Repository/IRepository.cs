﻿using System.Collections.Generic;

namespace InexikaTaskServer.DataAccess.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class
    {
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
