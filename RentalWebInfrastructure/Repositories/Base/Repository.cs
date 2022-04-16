
using Microsoft.EntityFrameworkCore;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories.Base;
using System.Linq.Expressions;

namespace RentalWebInfrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RentalWebContext context;
        protected DbSet<TEntity> _dbSet;

        public Repository(RentalWebContext dbContext)
        {
            context = dbContext ?? throw new Exception("ArgumentNullException", new ArgumentNullException(nameof(dbContext)));
            this._dbSet = context.Set<TEntity>();
        }

        #region Asynchronous

         public virtual async Task<IList<TEntity>> GetAsync()
        {
            try
            {
                return await context.Set<TEntity>().ToListAsync();

                //IQueryable<TEntity> query = context.Set<TEntity>();

                //if (predicate != null) query = query.Where(predicate);

                //return await query.ToListAsync();


            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public virtual async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (disableTracking) query = query.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

                if (predicate != null) query = query.Where(predicate);

                if (orderBy != null)
                    return await orderBy(query).ToListAsync();
                return await query.ToListAsync();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(Int64 id)
        {
            try
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            try
            {
                await context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public virtual void InsertRange(List<TEntity> entities)
        {
            try
            {
                context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        public virtual async Task InsertRangeAync(List<TEntity> entities)
        {
            try
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public virtual void UpdateRange(List<TEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    _dbSet.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        //public void DeleteRange(List<TEntity> entities)
        //{
        //    try
        //    {
        //        foreach (var entity in entities)
        //        {
        //            context.Set<TEntity>().Remove(entity);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //}

        public void Delete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        //public virtual async Task DeleteById(object id)
        //{
        //    try
        //    {
        //        TEntity entityToDelete = await _dbSet.FindAsync(id);
        //        Delete(entityToDelete);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion
    }
}
