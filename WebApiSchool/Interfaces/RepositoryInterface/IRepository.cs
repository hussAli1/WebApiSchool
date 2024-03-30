using System.Linq.Expressions;

namespace WebApiSchool.Interfaces.RepositoryInterface
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> CreateAsync(TEntity dbRecord);
        Task<TEntity> UpdateAsync(TEntity dbRecord);
        Task<bool> DeleteAsync(TEntity dbRecord);
    }
}
