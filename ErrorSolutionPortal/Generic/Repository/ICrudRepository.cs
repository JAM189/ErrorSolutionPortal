using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ErrorSolutionPortal
{
    public interface ICrudRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            );

        Task<TEntity> GetByProp(
            Expression<Func<TEntity, bool>> filter,
            string includeProperties = ""
            );

        Task<TEntity> GetFirstOrDefault<TResult>(
            //Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
            );


        Task<TEntity> GetById(TPrimaryKey id);

        Task Insert(TEntity entity);

        Task Delete(TPrimaryKey id);

        Task Delete(TEntity entityToDelete);

        Task Update(TEntity entityToUpdate);
    }
}
