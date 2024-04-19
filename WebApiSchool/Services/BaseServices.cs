using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiSchool.DataAccess;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Services
{
    public class BaseServices<TEntity> : IServices<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseServices(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
