using System.Linq.Expressions;

namespace WebApiSchool.Services.Interfaces
{
    public interface IServices<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
