using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EthicalScoring.Data.Repository
{

    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }

}