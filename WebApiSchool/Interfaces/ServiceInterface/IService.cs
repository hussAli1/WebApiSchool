using System.Linq.Expressions;

namespace WebApiSchool.Interfaces.ServiceInterface
{
    public interface IService<TEntity>
    {
        Task<List<TEntity>> GetEntityAllAsync();
        Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> CreateEntityAsync(TEntity dbRecord);
        Task<TEntity> UpdateEntityAsync(TEntity dbRecord);
        Task<bool> DeleteEntityAsync(TEntity dbRecord);
    }
}
