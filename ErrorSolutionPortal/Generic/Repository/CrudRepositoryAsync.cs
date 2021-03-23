using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ErrorSolutionPortal
{
    public abstract class CrudRepositoryAsync<TEntity, TPrimaryKey>
        : ICrudRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        protected IUnitOfWork unitOfWork;
        internal DbSet<TEntity> dbSet;

        public CrudRepositoryAsync(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbSet = unitOfWork.Context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<TEntity> GetFirstOrDefault<TResult>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            //if (orderBy != null)
            //{
            //    return orderBy(query).Select(selector).FirstOrDefault();
            //}
            //else
            //{
            //    return query.Select(selector).FirstOrDefault();
            //}

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public virtual async Task<TEntity> GetByProp(
            Expression<Func<TEntity, bool>> filter,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }

        public virtual async Task<TEntity> GetById(TPrimaryKey id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (entityToDelete is ISoftDeleteEntity<TPrimaryKey>)
            {
                ((ISoftDeleteEntity<TPrimaryKey>)entityToDelete).IsDeleted = true;
                dbSet.Attach(entityToDelete);
                unitOfWork.Context.Entry(entityToDelete).State = EntityState.Modified;
            }
            else
            {
                await Delete(entityToDelete);
            }
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (unitOfWork.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public virtual async Task Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            unitOfWork.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
