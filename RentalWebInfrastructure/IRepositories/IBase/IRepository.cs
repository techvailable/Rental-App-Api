using System.Linq.Expressions;

namespace RentalWebInfrastructure.IRepositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /*
        #region Synchronous

        IList<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void InsertRange(List<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(List<TEntity> entities);
        void Update(TEntity entityToUpdate);
        void UpdateRange(List<TEntity> entities);
        //void SynchronousSaveChanges();

        #endregion

        */

        #region Asynchronous
        Task<IList<TEntity>> GetAsync();
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        Task<TEntity> GetByIdAsync(Int64 id);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void InsertRange(List<TEntity> entity);
        Task InsertRangeAync(List<TEntity> entity);
        void Update(TEntity entityToUpdate);
        void UpdateRange(List<TEntity> entity);
        void Delete(TEntity entity);
        //void DeleteRange(List<TEntity> entity);
        //void DeleteById(object id); 

        #endregion
    }
}
