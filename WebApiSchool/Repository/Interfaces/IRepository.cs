using System.Linq.Expressions;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Select();

        Task<List<TEntity>> SelectAll();

        Task<TEntity> SelectById(object id);

        Task CreateAsync(TEntity entity);
        Task CreateAsync(List<TEntity> entity);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        public void DeleteRange(IEnumerable<TEntity> entity);

        Task<int> Count();

    }
}
