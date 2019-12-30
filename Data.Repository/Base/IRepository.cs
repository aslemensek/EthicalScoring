using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EthicalScoring.Data.Repository
{

    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(int id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }

}