using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WebApiSchool.Interfaces.RepositoryInterface;
using WebApiSchool.Interfaces.ServiceInterface;

namespace WebApiSchool.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public Task<TEntity> CreateEntityAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntityAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetEntityAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateEntityAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }
    }
}
